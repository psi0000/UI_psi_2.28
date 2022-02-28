using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI; // text 와  inputField 를 넣을려고 씀
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1.0";
    private string userId = "PSI";

    // 상태 창에 상태 텍스트 보여줄려고 변수 선언
    public TMP_Text StatusText;
    [SerializeField] public string Status = "Client";

    // 이름, 방코드 넣는 IF 변수 선언
    public TMP_InputField roomInput;
    public TMP_InputField NickNameInput;

    //스크린에서 빌드하기 위해서 이렇게 했다고 함 창 크기인거같음
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameVersion;
        Screen.SetResolution(1920, 1080, true);
        PhotonNetwork.ConnectUsingSettings();
    }


    // 상태 창 텍스트 넣기
    void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();



    // Connect 를 누르면 서버 접속함.

    //public void Connect() => PhotonNetwork.ConnectUsingSettings();

    //Call back 함수임. Call back 함수는 위 함수가 성공하면 => 이 함수가 호출 되라 라는 말임.
    //Call back 함수는 보통 On으로 시작함

    private void Start()
    {
        Debug.Log("포톤 매니저 시작");
    }
    public override void OnConnectedToMaster()
    {
        print("서버접속완료");

    }
  

    public void StartBtn()
    {
        userId = NickNameInput.text;
        PhotonNetwork.NickName = userId;
        Debug.Log("귀하의 닉네임은" + PhotonNetwork.NickName);
        PlayerPrefs.SetString("Player Name", NickNameInput.text);
        PhotonNetwork.JoinRoom(roomInput.text);
        
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방참가실패");
        PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
        Status = "Master";   //마스터이다
}

    // 서버 연결 끊기
    public void Disconnect()
    {

        PhotonNetwork.Disconnect();
        Debug.Log("연결 끊김");
        PlayerPrefs.DeleteAll();
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnDisconnected(DisconnectCause cause) => print("연결끊김");



    //로비 입장하기. 대형게임이 아닌이상 로비는 하나만 사용하면 됨
    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        print("로비접속완료");

    }
    //위 사항들은 다 방을 만드는데 쓰인 함수임.
    //방을 참가하거나 만들때는 OnConnectedToMaster 이거나 JoinLobby 가 되있어야 함.




    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 });


    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();



    //콜백 함수들. 사실 굳이 안해도 되는데 되는지 확인해 볼려고 하는거임.

    public override void OnCreatedRoom()
    {
        print("방만들기완료");
        Status = "Master";   //마스터이다

    }
    public override void OnJoinedRoom()
    {
        print("방입장완료");
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

    public override void OnCreateRoomFailed(short returnCode, string message) => print("방만들기실패");

    

}
