using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class QuestionChecker : MonoBehaviour
{
    

   
    public TMP_Text Question1;
    public TMP_Text Question2;
    public TMP_Text Question3;
    public TMP_Text Question4;
    public TMP_Text Question5;
    public TMP_Text Question6;

    public string status;

    // Start is called before the first frame update



    string question1 = null;
    string question2 = null;
    string question3 = null;
    string question4 = null;
    string question5 = null;
    string question6 = null;


    
    public void Update()
    {
        status = PlayerPrefs.GetString("Status");

        if (status == "Master")   //방을 만든 사람이면
        {
            Question1.text = null;
            Question2.text = null;
            Question3.text = null;
            question1 = PlayerPrefs.GetString("Question1");
            question2 = PlayerPrefs.GetString("Question2");
            question3 = PlayerPrefs.GetString("Question3");
           
            Question1.text = question1;
            Question2.text = question2;
            Question3.text = question3;
        }
        else if(status == "Client")
        {
            Question4.text = null;
            Question5.text = null;
            Question6.text = null;
            question4 = PlayerPrefs.GetString("Question4");
            question5 = PlayerPrefs.GetString("Question5");
            question6 = PlayerPrefs.GetString("Question6");
          
            Question4.text = question4;
            Question5.text = question5;
            Question6.text = question6;
        }
        

    }
   


    

}
