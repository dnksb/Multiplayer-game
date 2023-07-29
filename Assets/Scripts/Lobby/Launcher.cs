using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher instanse;

    public Text CreateRoomName;
    public Text ShowRoomName;
    public Transform RoomList;
    public GameObject RoomButtonPrefab;
    public Transform PlayerList;
    public GameObject PlayerTextPrefab;
    public GameObject StartButton;

    void Start()
    {
        instanse = this;
        Debug.Log("try connect to master");
        PhotonNetwork.ConnectUsingSettings();
        MenuController.instanse.Open("LoadingMenu");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("connected to lobby");
        MenuController.instanse.Open("TitleMenu");
        PhotonNetwork.NickName = $"Игрок: {Random.Range(0,1000)}";
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("connected to lobby");
        ShowRoomName.text = PhotonNetwork.CurrentRoom.Name;
        MenuController.instanse.Open("RoomMenu");

        for (int i = 0; i < PlayerList.childCount; i++)
        {
            Destroy(PlayerList.GetChild(i).gameObject);
        }

        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(PlayerTextPrefab, PlayerList).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        StartButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMaster)
    {
        StartButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"{returnCode}: {message}");
        MenuController.instanse.Open("Error");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("disconnected for Room");
        MenuController.instanse.Open("TitleMenu");
    }

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        for (int i = 0; i < RoomList.childCount; i++)
        {
            Destroy(RoomList.GetChild(i).gameObject);
        }
        for (int i = 0; i < _roomList.Count; i++)
        {
            if(_roomList[i].RemovedFromList)
                continue;
            Instantiate(RoomButtonPrefab, RoomList).GetComponent<RoomListener>().SetUp(_roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player _player)
    {
        Debug.Log("connected to lobby new player");
        Instantiate(PlayerTextPrefab, PlayerList).GetComponent<PlayerListItem>().SetUp(_player);
    }

    public void CreateRoom()
    {
        string tmp = CreateRoomName.text;
        if(string.IsNullOrEmpty(tmp))
        {
            Debug.Log("lobby name is null");
            MenuController.instanse.Open("Error");
            return;
        }
        Debug.Log($"create lobby with such name: {tmp}");
        PhotonNetwork.CreateRoom(tmp);
        MenuController.instanse.Open("LoadingMenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuController.instanse.Open("LoadingMenu");
    }

    public void JoinRoom(RoomInfo _info)
    {
        PhotonNetwork.JoinRoom(_info.Name);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
