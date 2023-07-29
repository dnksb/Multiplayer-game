using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView View;
    public float value;
    float tmp_time;
    public float speed;
    public Transform Health;

    void Start()
    {
        View = GetComponent<PhotonView>();
        if(View.IsMine)
        {
            CreateController();
        }

        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "Health"),
            Health.position = new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
            Quaternion.identity);
        tmp_time = value;
    }

    private void Update()
    {
        tmp_time -= Time.deltaTime * speed;
        if (tmp_time < 0)
        {
            PhotonNetwork.Instantiate(
                Path.Combine("PhotonPrefabs", "Health"),
                Health.position = new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
                Quaternion.identity);
            tmp_time = value;
        }
    }
    void CreateController()
    {
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "PlayerPrefab"),
            Health.position = new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
            Quaternion.identity);
    }

}
