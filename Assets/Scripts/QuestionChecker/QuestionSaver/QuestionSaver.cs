using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionSaver : MonoBehaviour
{

    public TMP_InputField Question_InputField1;
    public TMP_InputField Question_InputField2;
    public TMP_InputField Question_InputField3;
    public string status; 
    


    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    // Update is called once per frame
    void Update()
    {
        status = PlayerPrefs.GetString("Status");
    }

    public void QuestionReset1()
    {
        
        PlayerPrefs.DeleteKey("Question1");
        Debug.Log("질문1 수정");

    }

    public void QuestionReset2()
    {

        PlayerPrefs.DeleteKey("Question2");
        Debug.Log("질문2 수정");

    }

    public void QuestionReset3()
    {

        PlayerPrefs.DeleteKey("Question3");
        Debug.Log("질문3 수정");

    }
    public void QuestionReset4()
    {

        PlayerPrefs.DeleteKey("Question4");
        Debug.Log("질문4 수정");

    }
    public void QuestionReset5()
    {

        PlayerPrefs.DeleteKey("Question5");
        Debug.Log("질문5 수정");

    }
    public void QuestionReset6()
    {

        PlayerPrefs.DeleteKey("Question6");
        Debug.Log("질문6 수정");

    }





    


    public void QuestionSave1()
    {
        if (status == "Master")   //방을 만든 사람이면
        {
            QuestionReset1();
            PlayerPrefs.SetString("Question1", Question_InputField1.text);
            Debug.Log("질문 1 저장 완료"+ Question_InputField1.text);

        }
        else 
        {
            QuestionReset4();
            PlayerPrefs.SetString("Question4", Question_InputField1.text);
            Debug.Log("질문 4 저장 완료"+ Question_InputField1.text);
        }
        
    }

    public void QuestionSave2()
    {
        if (status == "Master")   //방을 만든 사람이면
        {
            QuestionReset2();
            PlayerPrefs.SetString("Question2", Question_InputField2.text);
            Debug.Log("질문 2 저장 완료  "+ Question_InputField2.text);

        }
        else
        {
            QuestionReset5();
            PlayerPrefs.SetString("Question5", Question_InputField2.text);
            Debug.Log("질문 5 저장 완료  "+ Question_InputField2.text);
        }
    }

    public void QuestionSave3()
    {
        if (status == "Master")   //방을 만든 사람이면
        {
            QuestionReset3();
            PlayerPrefs.SetString("Question3", Question_InputField3.text);
            Debug.Log("질문 3 저장 완료  "+ Question_InputField3.text);

        }
        else
        {
            QuestionReset6();
            PlayerPrefs.SetString("Question6", Question_InputField3.text);
            Debug.Log("질문 6 저장 완료  "+ Question_InputField3.text);
        }
    }

}
