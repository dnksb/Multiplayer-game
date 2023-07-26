using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        MenuController.instanse.Open("LoadingMenu");
        Debug.Log("try connect to master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("connected to lobby");
        MenuController.instanse.Open("RoomMenu");
    }
}
