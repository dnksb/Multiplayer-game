using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListener : MonoBehaviour
{
    public Text RoomName;
    public RoomInfo info;

    public void SetUp(RoomInfo value)
    {
        info = value;
        RoomName.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.instanse.JoinRoom(info);
    }

}
