using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Controller : MonoBehaviour
{
    public TMP_InputField NickName_inputField;
    public TMP_InputField RoomCode_inputField;
    public Button Next_Button;
    public Button Exit_Button;
    public GameObject popUp_Exit;




    bool isCursorSwap = false;

    // Start is called before the first frame update
    void Start()
    {
        NickName_inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneChanger_toKeyword();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCursorSwap = !isCursorSwap;
            if (isCursorSwap)
            {
                RoomCode_inputField.ActivateInputField();
                StartCoroutine(TextCursorMoveEnd(RoomCode_inputField));
            }
            else
            {
                NickName_inputField.ActivateInputField();
                StartCoroutine(TextCursorMoveEnd(NickName_inputField));
            }
        }

        IEnumerator TextCursorMoveEnd(TMP_InputField inputField)
        {
            yield return 0;
            inputField.MoveTextEnd(false);
        }

    }
    

    public void SceneChanger_toStartScene()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("StartScene");
    }

    public void SceneChanger_toKeyword()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("KeywordScene");
    }
    public void SceneChanger_toKeyword2()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("KeywordScene2");

    }public void SceneChanger_toKeyword3()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("KeywordScene3");
    }


}
