using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView View;

    void Start()
    {
        View = GetComponent<PhotonView>();
        if(View.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "PlayerPrefab"),
            new Vector3(0, 2, 0),
            Quaternion.identity);
    }

}
