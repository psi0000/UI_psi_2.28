using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
public class Mute : MonoBehaviour
{
   
    public AudioSource amp;
    private void Start()
    {
        amp = amp.transform.GetComponent<AudioSource>();
    }
    public void Mutebtn()
    {
        
        if (amp.mute == true)
        {
           amp.mute = false;
            Debug.Log("�Ҹ������");
        }
        else
        {
            amp.mute = true;
            Debug.Log("��Ʈ");
        }
        
    }
}
