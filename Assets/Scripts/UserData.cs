using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserData : MonoBehaviour
{
    public static string username;
    public static string gender;
    public static string grade;
    public static string school;

    public static bool Sended = false;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI Gender;
    public TextMeshProUGUI Grade;
    public TextMeshProUGUI School;


    public RawImage ProfilePic;
    public Texture Male;
    public Texture Female;

    void Update()
    {
        if (Sended == true)
        {
            NameText.text = username.ToString();
            Gender.text = gender.ToString();
            Grade.text = grade.ToString();
            School.text = school.ToString();

            if(Gender.text == "" || Gender.text == "Male")
            {
                ProfilePic.texture = Male;
            }
            else
            {
                ProfilePic.texture = Female;
            }
            
        }
    }

}
