using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{


    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            other.GetComponent<InputController>().HP += 20;
            Destroy(gameObject);
        }
    }
}
