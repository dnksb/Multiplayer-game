using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    Player player;

    public void SetUp(Player _player)
    {
        player = _player;
        GetComponent<Text>().text = player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("disconnected for lobby other player");
        if(player == otherPlayer)
            Destroy(gameObject);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("disconnected for lobby");
        Destroy(gameObject);
    }
}
