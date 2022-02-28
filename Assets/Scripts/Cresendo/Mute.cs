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
            Debug.Log("소리들려요");
        }
        else
        {
            amp.mute = true;
            Debug.Log("뮤트");
        }
        
    }
}
