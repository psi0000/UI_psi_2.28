using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;
using TMPro;

public class RPC_Q1_3 : MonoBehaviourPunCallbacks
{

    public TMP_Text Q1;
    public TMP_Text Q2;
    public TMP_Text Q3;
    
  

    private PhotonView pv;

    // Start is called before the first frame update
     void Update()
    {

        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            string str1 = PlayerPrefs.GetString("Question1");
            string str2 = PlayerPrefs.GetString("Question2");
            string str3 = PlayerPrefs.GetString("Question3");
            

            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str1,1);
            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str2,2);
            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str3,3);
          
            
        }else
        {
            return;
        }
        
        
        
    }

    [PunRPC]
    void Send(string str,int idx)
    {
        switch (idx)
        {
            case 1:
                Q1.text = str;
                break;
            case 2:
                Q2.text = str;
                break;
            case 3:
                Q3.text = str;
                break;
            
        }
        
       
       
    }

    
}
