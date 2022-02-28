using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
    public void SceneChanger_toKeyword3()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("KeywordScene3");
    }

    public void SceneChanger_toEnterScene()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync("EnterScene");
    }

}
