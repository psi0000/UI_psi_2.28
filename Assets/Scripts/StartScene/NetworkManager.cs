using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI; // text ��  inputField �� �������� ��
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1.0";
    private string userId = "PSI";

    // ���� â�� ���� �ؽ�Ʈ �����ٷ��� ���� ����
    public TMP_Text StatusText;
    [SerializeField] public string Status = "Client";

    // �̸�, ���ڵ� �ִ� IF ���� ����
    public TMP_InputField roomInput;
    public TMP_InputField NickNameInput;

    //��ũ������ �����ϱ� ���ؼ� �̷��� �ߴٰ� �� â ũ���ΰŰ���
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameVersion;
        Screen.SetResolution(1920, 1080, true);
        PhotonNetwork.ConnectUsingSettings();
    }


    // ���� â �ؽ�Ʈ �ֱ�
    void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();



    // Connect �� ������ ���� ������.

    //public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //Call back �Լ���. Call back �Լ��� �� �Լ��� �����ϸ� => �� �Լ��� ȣ�� �Ƕ� ��� ����.
    //Call back �Լ��� ���� On���� ������

    private void Start()
    {
        Debug.Log("���� �Ŵ��� ����");
    }
    public override void OnConnectedToMaster()
    {
        print("�������ӿϷ�");

    }
  

    public void StartBtn()
    {
        userId = NickNameInput.text;
        PhotonNetwork.NickName = userId;
        Debug.Log("������ �г�����" + PhotonNetwork.NickName);
        PlayerPrefs.SetString("Player Name", NickNameInput.text);
        PhotonNetwork.JoinRoom(roomInput.text);
        
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("����������");
        PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
        Status = "Master";   //�������̴�
}

    // ���� ���� ����
    public void Disconnect()
    {

        PhotonNetwork.Disconnect();
        Debug.Log("���� ����");
        PlayerPrefs.DeleteAll();
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnDisconnected(DisconnectCause cause) => print("�������");



    //�κ� �����ϱ�. ���������� �ƴ��̻� �κ�� �ϳ��� ����ϸ� ��
    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        print("�κ����ӿϷ�");

    }
    //�� ���׵��� �� ���� ����µ� ���� �Լ���.
    //���� �����ϰų� ���鶧�� OnConnectedToMaster �̰ų� JoinLobby �� ���־�� ��.




    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 });


    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();



    //�ݹ� �Լ���. ��� ���� ���ص� �Ǵµ� �Ǵ��� Ȯ���� ������ �ϴ°���.

    public override void OnCreatedRoom()
    {
        print("�游���Ϸ�");
        Status = "Master";   //�������̴�

    }
    public override void OnJoinedRoom()
    {
        print("������Ϸ�");
        Debug.Log(Status);
        PlayerPrefs.DeleteKey("Status");
        PlayerPrefs.SetString("Status",Status);
        
    }

    public void SceneChanger()
    {
      if (PhotonNetwork.IsMasterClient)
        {

            //Destroy(gameObject);
            //PhotonNetwork.LoadLevel("Cresendo");
           

        }
        

    }

    public override void OnCreateRoomFailed(short returnCode, string message) => print("�游������");

    

}
