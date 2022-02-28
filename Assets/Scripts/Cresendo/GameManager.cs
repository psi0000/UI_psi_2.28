using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    string status;
    
    void Awake()
    {
        CreatePlayer();
        

    }
    private void Start()
    {

        status = PlayerPrefs.GetString("Status");
        if (status == "Master")   //방을 만든 사람이면
        {
            QuestionSpawn1_3();
        }
        else if (status == "Client")
        {
            QuestionSpawn4_6();
            return;
        }
    }

    void CreatePlayer()
    {
        // 출현 위치 정보를 배열에 저장
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        // 네트워크상에 캐릭터 생성
        PhotonNetwork.Instantiate("Player",
                                  points[idx].position,
                                  points[idx].rotation,
                                  0);
    }
    void QuestionSpawn1_3()
    {
        // 출현 위치 정보를 배열에 저장
        Transform[] points = GameObject.Find("QuestionPoint1_3").GetComponents<Transform>();
        PhotonNetwork.Instantiate("Q1_3",
                                      points[0].position,
                                      points[0].rotation,
        
                                      0);
        /*
        for (int i = 1; i < points.Length; i++)
        {
            // 네트워크상에 캐릭터 생성
            PhotonNetwork.Instantiate("Q",
                                      points[i].position,
                                      points[i].rotation,
                                      0);
        }
*/

    }
    void QuestionSpawn4_6()
    {
        // 출현 위치 정보를 배열에 저장
        Transform[] points = GameObject.Find("QuestionPoint4_6").GetComponents<Transform>();
        PhotonNetwork.Instantiate("Q4_6",
                                      points[0].position,
                                      points[0].rotation,

                                      0);



        /*for (int i = 1; i < points.Length; i++)
        {
            // 네트워크상에 캐릭터 생성
            PhotonNetwork.Instantiate("Q",
                                      points[i].position,
                                      points[i].rotation,
                                      0);
        }
        */


    }
}
