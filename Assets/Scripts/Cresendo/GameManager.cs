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
        if (status == "Master")   //���� ���� ����̸�
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
        // ���� ��ġ ������ �迭�� ����
        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        // ��Ʈ��ũ�� ĳ���� ����
        PhotonNetwork.Instantiate("Player",
                                  points[idx].position,
                                  points[idx].rotation,
                                  0);
    }
    void QuestionSpawn1_3()
    {
        // ���� ��ġ ������ �迭�� ����
        Transform[] points = GameObject.Find("QuestionPoint1_3").GetComponents<Transform>();
        PhotonNetwork.Instantiate("Q1_3",
                                      points[0].position,
                                      points[0].rotation,
        
                                      0);
        /*
        for (int i = 1; i < points.Length; i++)
        {
            // ��Ʈ��ũ�� ĳ���� ����
            PhotonNetwork.Instantiate("Q",
                                      points[i].position,
                                      points[i].rotation,
                                      0);
        }
*/

    }
    void QuestionSpawn4_6()
    {
        // ���� ��ġ ������ �迭�� ����
        Transform[] points = GameObject.Find("QuestionPoint4_6").GetComponents<Transform>();
        PhotonNetwork.Instantiate("Q4_6",
                                      points[0].position,
                                      points[0].rotation,

                                      0);



        /*for (int i = 1; i < points.Length; i++)
        {
            // ��Ʈ��ũ�� ĳ���� ����
            PhotonNetwork.Instantiate("Q",
                                      points[i].position,
                                      points[i].rotation,
                                      0);
        }
        */


    }
}
