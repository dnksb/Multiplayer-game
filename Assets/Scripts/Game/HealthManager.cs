using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float value;
    float tmp_time;
    public float speed;
    public Transform Health;

    public void Start()
    {
        Instantiate(Health);
        Health.position = new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10));
        tmp_time = value;
    }

    private void Update()
    {
        tmp_time -= Time.deltaTime * speed;
        if (tmp_time < 0)
        {
            Instantiate(Health);
            Health.position = new Vector3(Random.Range(-9,9), 0.5f, Random.Range(-2,10));
            tmp_time = value;
        }
    }
}
