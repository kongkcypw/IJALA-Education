using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    public GameObject name;
    public GameObject gender;
    public GameObject school;
    public GameObject grade;

    private string Name;
    private string Gender;
    private string School;
    private string Grade;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdMLOqrxccFj_f3kW7xNmonbrpAm-TQ0sYwvnBTYwi3GZyreA/formResponse";

    IEnumerator Post(string name, string gender, string school, string grade)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1430527111", name);
        form.AddField("entry.1170724713", gender);
        form.AddField("entry.2145413337", school);
        form.AddField("entry.555992046", grade);

        /*
        ** Outdated
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
        */

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

    public void Send()
    {
        Name = name.GetComponent<InputField>().text;
        Gender = gender.GetComponent<InputField>().text;
        School = school.GetComponent<InputField>().text;
        Grade = grade.GetComponent<InputField>().text;
        StartCoroutine(Post(Name, Gender, School, Grade));
    }
}
