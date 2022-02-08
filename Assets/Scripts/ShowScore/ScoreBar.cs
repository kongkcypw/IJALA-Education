using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class ScoreBar : MonoBehaviour
{
    /// Multiple Choices
    public Image McEasy_Scorebar;
    public static float McEasy_CurrentScore;
    public float McEasy_MaxScore;
    public TextMeshProUGUI McEasyText;
    public TextMeshProUGUI McEasyPercent;

    public Image McNormal_Scorebar;
    public static float McNormal_CurrentScore;
    public float McNormal_MaxScore;
    public TextMeshProUGUI McNormalText;
    public TextMeshProUGUI McNormalPercent;

    public Image McHard_Scorebar;
    public static float McHard_CurrentScore;
    public float McHard_MaxScore;
    public TextMeshProUGUI McHardText;
    public TextMeshProUGUI McHardPercent;

    /// Match Up
    public Image Mu_Scorebar;
    public static float MuRemainingTime;
    public static int MuScore;
    public float MU_MaxScore;
    public float MU_MaxTime;
    public TextMeshProUGUI MuTotalScore;
    public TextMeshProUGUI MuPercent;

    /// Memory
    public Image SRMem_Scorebar;
    public static float SRMemRemainingTime;
    public static int SRMemScore;
    public float SRMem_MaxScore;
    public float SRMem_MaxTime;
    public TextMeshProUGUI SRMemTotalScore;
    public TextMeshProUGUI SRMemPercent;

    public Image EXpoMem_Scorebar;
    public static float EXpoMemRemainingTime;
    public static int ExpoMemScore;
    public float EXpoMem_MaxScore;
    public float EXpoMem_MaxTime;
    public TextMeshProUGUI EXpoMemTotalScore;
    public TextMeshProUGUI EXpoMemPercent;

    public Image FtMem_Scorebar;
    public static float FtMemRemainingTime;
    public static int FtMemScore;
    public float FtMem_MaxScore;
    public float FtMem_MaxTime;
    public TextMeshProUGUI FtMemTotalScore;
    public TextMeshProUGUI FtMemPercent;

    // User Data
    private string Name;
    private string Gender;
    private string School;
    private string Grade;
    // All Score
    private string MatchUp;
    private string McEasy;
    private string McNormal;
    private string McHard;
    private string MemSR;
    private string MemEX;
    private string MemFT;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/4/d/e/1FAIpQLScEm9UbX2Pr9vWYSvy69NHk6N8FKVO8kxlLk5PbGcVQXvoNpQ/formResponse";

    [System.Obsolete]
    IEnumerator Post(string name, string gender, string school, string grade, string matchup, string mcEasy, string mcNormal, string mcHard,
                     string memSR, string memEX, string memFt)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.23068942", name);
        form.AddField("entry.870335562", gender);
        form.AddField("entry.564030512", school);
        form.AddField("entry.9455542", grade);
        form.AddField("entry.189707214", matchup);
        form.AddField("entry.671109958", mcEasy);
        form.AddField("entry.1505441077", mcNormal);
        form.AddField("entry.1292600495", mcHard);
        form.AddField("entry.108399946", memSR);
        form.AddField("entry.298381538", memEX);
        form.AddField("entry.644289136", memFt);


        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();


        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    public void SendToGoogleForm()
    {
        // Send to Google Form
        Name = UserData.username;
        Gender = UserData.gender;
        School = UserData.school;
        Grade = UserData.grade;

        MatchUp = MuTotalScore.text;
        McEasy = McEasyText.text;
        McNormal = McNormalText.text;
        McHard = McHardText.text;
        MemSR = SRMemTotalScore.text;
        MemEX = EXpoMemTotalScore.text;
        MemFT = FtMemTotalScore.text;

        StartCoroutine(Post(Name, Gender, School, Grade, MatchUp, McEasy, McNormal, McHard, MemSR, MemEX, MemFT));
    }

    private void Update()
    {
        //Multiple Choices
        McEasy_Scorebar.fillAmount = McEasy_CurrentScore / McEasy_MaxScore;
        McEasyText.text = McEasy_CurrentScore.ToString() + " / " + McEasy_MaxScore.ToString();
        McEasyPercent.text = (McEasy_CurrentScore / McEasy_MaxScore * 100).ToString() + "%";

        McNormal_Scorebar.fillAmount = McNormal_CurrentScore / McNormal_MaxScore;
        McNormalText.text = McNormal_CurrentScore.ToString() + " / " + McNormal_MaxScore.ToString();
        McNormalPercent.text = (McNormal_CurrentScore / McNormal_MaxScore * 100).ToString() + "%";

        McHard_Scorebar.fillAmount = McHard_CurrentScore / McHard_MaxScore;
        McHardText.text = McHard_CurrentScore.ToString() + " / " + McHard_MaxScore.ToString();
        McHardPercent.text = (McHard_CurrentScore / McHard_MaxScore * 100).ToString() + "%";


        //Match Up
        Mu_Scorebar.fillAmount = (MuScore * MuRemainingTime) / (MU_MaxScore * MU_MaxTime);
        MuTotalScore.text = (MuScore * MuRemainingTime).ToString("F1") + " / " + (MU_MaxScore * MU_MaxTime).ToString();
        MuPercent.text = ((MuScore * MuRemainingTime) / (MU_MaxScore * MU_MaxTime) * 100f).ToString("F1") + "%";


        //Memory
        SRMem_Scorebar.fillAmount = (SRMemScore * SRMemRemainingTime) / (SRMem_MaxScore * SRMem_MaxTime);
        SRMemTotalScore.text = (SRMemScore * SRMemRemainingTime).ToString("F1") + " / " + (SRMem_MaxScore * SRMem_MaxTime).ToString();
        SRMemPercent.text = ((SRMemScore * SRMemRemainingTime) / (SRMem_MaxScore * SRMem_MaxTime) * 100).ToString("F1");

        EXpoMem_Scorebar.fillAmount = (ExpoMemScore * EXpoMemRemainingTime) / (EXpoMem_MaxScore * EXpoMem_MaxTime);
        EXpoMemTotalScore.text = (ExpoMemScore * EXpoMemRemainingTime).ToString("F1") + " / " + (EXpoMem_MaxScore * EXpoMem_MaxTime).ToString();
        EXpoMemPercent.text = ((ExpoMemScore * EXpoMemRemainingTime) / (EXpoMem_MaxScore * EXpoMem_MaxTime) * 100).ToString("F1");

        FtMem_Scorebar.fillAmount = (FtMemScore * FtMemRemainingTime) / (FtMem_MaxScore * FtMem_MaxTime);
        FtMemTotalScore.text = (FtMemScore * FtMemRemainingTime).ToString("F1") + " / " + (FtMem_MaxScore * FtMem_MaxTime).ToString();
        FtMemPercent.text = ((FtMemScore * FtMemRemainingTime) / (FtMem_MaxScore * FtMem_MaxTime) * 100).ToString("F1");

    }
}
