using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string version = "1.0f";
    private string userId = "Zack";

    // 이름, 방코드 넣는 IF 변수 선언
    public TMP_InputField roomInput;
    public TMP_InputField NickNameInput;
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userId;

        Debug.Log(PhotonNetwork.SendRate);

        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        // 저장된 유저명 로드
        userId = PlayerPrefs.GetString("USER_ID", $"USER_{Random.Range(1, 21):00}");
        NickNameInput.text = userId;
        // 접속 유저의 닉네임 등록
        PhotonNetwork.NickName = userId;
    }


    // 유저명을 설정하는 로직
    public void SetUserId()
    {
        if (string.IsNullOrEmpty(NickNameInput.text))
        {
            userId = $"USER_{Random.Range(1, 21):00}";
        }
        else
        {
            userId = NickNameInput.text;
        }
        // 유저명 저장
        PlayerPrefs.SetString("USER_ID", userId);
        // 접속 유저의 닉네임 등록
        PhotonNetwork.NickName = userId;
    }
    string SetRoomName()
    {
        if (string.IsNullOrEmpty(roomInput.text))
        {
            roomInput.text = $"ROOM_{Random.Range(1, 101):000}";
        }

        return roomInput.text;
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandomFailed {returnCode}:{message}");
        // 룸을 생성하는 함수 실행
        OnMakeRoomClick();

        // 룸을 생성하고 입장. 속성 설정.
        //RoomOptions ro = new RoomOptions();
        //ro.MaxPlayers = 20;     // 룸에 접속할 수 있는 최대 접속자 수
        //ro.IsOpen = true;       // 룸의 오픈 여부
        //ro.IsVisible = true;    // 로비에서 룸 목록에 룸을 노출시킬지 여부

        //PhotonNetwork.CreateRoom("My Room", ro);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }

        // 스폰 포인트의 랜덤한 위치에 플레이어를 스폰함.
        // Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        // int idx = Random.Range(1, points.Length);

        // PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);

        // 마스터 클라이언트인 경우에 룸에 입장한 후 전투 씬을 로딩
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Cresendo");
        }
    }

    #region UI_BUTTON_EVENT

    public void OnLoginClick()
    {
        // 유저명 저장
        SetUserId();

        // 무작위로 추출한 룸으로 입장
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnMakeRoomClick()
    {
        // 유저명 저장
        SetUserId();

        // 룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;     // 룸에 입장할 수 있는 최대 접속자 수
        ro.IsOpen = true;       // 룸의 오픈 여부
        ro.IsVisible = true;    // 로비에서 룸 목록에 노출시킬 여부

        // 룸 생성
        PhotonNetwork.CreateRoom(SetRoomName(), ro);
    }

    #endregion





}


