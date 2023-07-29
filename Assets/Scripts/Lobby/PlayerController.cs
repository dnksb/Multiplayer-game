using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
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
            new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
            Quaternion.identity);
    }

}
