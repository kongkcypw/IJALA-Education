using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowChoosed : MonoBehaviour
{
    public TMP_Dropdown genderDropdown;
    public Text genderShow;
    public TMP_Dropdown gradeDropdown;
    public Text gradeShow;

    // Start is called before the first frame update
    void Start()
    {
        genderShow.text = genderDropdown.options[genderDropdown.value].text;
        gradeShow.text = gradeDropdown.options[gradeDropdown.value].text;
    }

    // Update is called once per frame
    void Update()
    {
        genderShow.text = genderDropdown.options[genderDropdown.value].text;
        gradeShow.text = gradeDropdown.options[gradeDropdown.value].text;
    }
}
