using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;
using TMPro;

public class RPC_Q4_6 : MonoBehaviourPunCallbacks
{

    
    public TMP_Text Q4;
    public TMP_Text Q5;
    public TMP_Text Q6;
  

    private PhotonView pv;

    // Start is called before the first frame update
     void Update()
    {

        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            
            string str4 = PlayerPrefs.GetString("Question4");
            string str5 = PlayerPrefs.GetString("Question5");
            string str6 = PlayerPrefs.GetString("Question6");

           
            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str4,4);
            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str5,5);
            pv.RPC(nameof(Send), RpcTarget.AllBufferedViaServer, str6,6);
            
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
            
            case 4:
                Q4.text = str;
                break;
            case 5:
                Q5.text = str;
                break;
            case 6:
                Q6.text = str;
                break;
        }
        
       
       
    }

    
}
