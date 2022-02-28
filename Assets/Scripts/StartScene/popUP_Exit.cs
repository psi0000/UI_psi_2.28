using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUP_Exit : MonoBehaviour
{

    public GameObject popUp_Exit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {


            if (popUp_Exit.activeSelf)
            {
                popUp_Exit.SetActive(false);

            }

            else
            {
                popUp_Exit.SetActive(true);

            }
        }
    }
}

