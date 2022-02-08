using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBar : MonoBehaviour
{
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


    private void Update()
    {
        McEasy_Scorebar.fillAmount = McEasy_CurrentScore / McEasy_MaxScore;
        McEasyText.text = McEasy_CurrentScore.ToString() + " / " + McEasy_MaxScore.ToString();
        McEasyPercent.text = (McEasy_CurrentScore / McEasy_MaxScore * 100).ToString() + "%";

        McNormal_Scorebar.fillAmount = McNormal_CurrentScore / McNormal_MaxScore;
        McNormalText.text = McNormal_CurrentScore.ToString() + " / " + McNormal_MaxScore.ToString();
        McNormalPercent.text = (McNormal_CurrentScore / McNormal_MaxScore * 100).ToString() + "%";

        McHard_Scorebar.fillAmount = McHard_CurrentScore / McHard_MaxScore;
        McHardText.text = McHard_CurrentScore.ToString() + " / " + McHard_MaxScore.ToString();
        McHardPercent.text = (McHard_CurrentScore / McHard_MaxScore * 100).ToString() + "%";
    }
}
