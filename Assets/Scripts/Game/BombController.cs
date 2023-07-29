using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float SpeedMove;

    public void FixedUpdate()
    {
        gameObject.transform.localPosition += new Vector3(
            Mathf.Cos(transform.eulerAngles.y) * SpeedMove,
            0,
            Mathf.Sin(transform.eulerAngles.y) * SpeedMove
        );
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall")
            Destroy(gameObject);
    }
}
