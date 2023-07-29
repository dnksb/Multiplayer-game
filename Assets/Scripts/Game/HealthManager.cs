using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthManager : MonoBehaviour
{
    public float value;
    float tmp_time;
    public float speed;

    void Start()
    {
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "Health"),
            new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
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
                new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10)),
                Quaternion.identity);
            tmp_time = value;
        }
    }
}
