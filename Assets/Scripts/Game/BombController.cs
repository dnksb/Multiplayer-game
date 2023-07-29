using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float SpeedMove;

    public void Start()
    {
        transform.Translate(0, 0, 1);
    }

    public void FixedUpdate()
    {
        transform.Translate(0, 0, SpeedMove);
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall")
            Destroy(gameObject);
    }
}
