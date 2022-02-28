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

    // �̸�, ���ڵ� �ִ� IF ���� ����
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
        // ����� ������ �ε�
        userId = PlayerPrefs.GetString("USER_ID", $"USER_{Random.Range(1, 21):00}");
        NickNameInput.text = userId;
        // ���� ������ �г��� ���
        PhotonNetwork.NickName = userId;
    }


    // �������� �����ϴ� ����
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
        // ������ ����
        PlayerPrefs.SetString("USER_ID", userId);
        // ���� ������ �г��� ���
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
        // ���� �����ϴ� �Լ� ����
        OnMakeRoomClick();

        // ���� �����ϰ� ����. �Ӽ� ����.
        //RoomOptions ro = new RoomOptions();
        //ro.MaxPlayers = 20;     // �뿡 ������ �� �ִ� �ִ� ������ ��
        //ro.IsOpen = true;       // ���� ���� ����
        //ro.IsVisible = true;    // �κ񿡼� �� ��Ͽ� ���� �����ų�� ����

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

        // ���� ����Ʈ�� ������ ��ġ�� �÷��̾ ������.
        // Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        // int idx = Random.Range(1, points.Length);

        // PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);

        // ������ Ŭ���̾�Ʈ�� ��쿡 �뿡 ������ �� ���� ���� �ε�
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Cresendo");
        }
    }

    #region UI_BUTTON_EVENT

    public void OnLoginClick()
    {
        // ������ ����
        SetUserId();

        // �������� ������ ������ ����
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnMakeRoomClick()
    {
        // ������ ����
        SetUserId();

        // ���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;     // �뿡 ������ �� �ִ� �ִ� ������ ��
        ro.IsOpen = true;       // ���� ���� ����
        ro.IsVisible = true;    // �κ񿡼� �� ��Ͽ� �����ų ����

        // �� ����
        PhotonNetwork.CreateRoom(SetRoomName(), ro);
    }

    #endregion





}


