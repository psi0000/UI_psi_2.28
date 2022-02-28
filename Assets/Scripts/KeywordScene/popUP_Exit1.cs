using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUP_Exit1 : MonoBehaviour
{

    public GameObject popUp_Exit;
    public GameObject Info_Confirm;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {

            if (Info_Confirm.activeSelf)
            {
                Info_Confirm.SetActive(false);
            }


            else if (popUp_Exit.activeSelf)
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
