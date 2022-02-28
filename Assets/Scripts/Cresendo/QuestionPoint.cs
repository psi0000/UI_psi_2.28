using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;


public class QuestionPoint : MonoBehaviourPunCallbacks
{/*
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;

    private PhotonView pv;

    private int idxMt = -1;
    public Material[] playerMt;
    


    private void OnCollisionEnter(Collider other)
    {
        string coll = other.gameObject.name;
        switch (coll)
        {
            case "QuestionPoint1":
                pv.RPC(nameof(SetMt), RpcTarget.AllViaServer, 0);
                break;
            case "QuestionPoint2":
                pv.RPC(nameof(SetMt), RpcTarget.AllViaServer, 1);
                break;
            case "QuestionPoint3":
                pv.RPC(nameof(SetMt), RpcTarget.AllViaServer, 2);
                break;
        }
    }
    [PunRPC]
    private void SetMt(int idx)
    {
        GetComponent<Renderer>().material = playerMt[idx];
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log($"1.{idxMt}");
        if (pv.IsMine && idxMt != -1)
        {
            Debug.Log($"2.{idxMt}");
            pv.RPC(nameof(SetMt), newPlayer, idxMt);
        }
    }*/
}
