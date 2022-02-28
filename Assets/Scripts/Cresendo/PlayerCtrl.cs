using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;

public class PlayerCtrl : MonoBehaviourPunCallbacks
{
    private new Rigidbody rigidbody;
    private PhotonView pv;

    private float v;
    private float h;
    private float r;

    [Header("이동 및 회전 속도")]
    public float moveSpeed = 8.0f;
    public float turnSpeed = 200.0f;
    public float jumpPower = 50.0f;

    private float turnSpeedValue = 0.0f;

    private RaycastHit hit;

    //public Material[] playerMt;
    

    IEnumerator Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();

        turnSpeedValue = turnSpeed;
        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.5f);

       if (pv.IsMine)
        {
            Camera.main.GetComponent<SmoothFollow>().target = transform.Find("CamPivot").transform;

        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;

        }

        turnSpeed = turnSpeedValue;
    }


    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        r = Input.GetAxis("Mouse X");

        Debug.DrawRay(transform.position, -transform.up * 0.6f, Color.green);
        if (Input.GetKeyDown("space"))//Input.GetKeyDown("space")
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit, 0.6f))
            {
                rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
       //Debug.Log($"update.{idxMt}");

    }
    //물리적 처리
    private void FixedUpdate()
    {
        if (pv.IsMine)
        {
            Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
            transform.Rotate(Vector3.up * Time.smoothDeltaTime * turnSpeed * r);
        }

    }




}