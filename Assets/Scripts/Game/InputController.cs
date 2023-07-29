using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InputController : MonoBehaviour
{
    PhotonView View;

    public Rigidbody Body;
    public FixedJoystick Joystick;
    public Animator animator;

    public float SpeedMove;

    public int HP;
    public Text HpText;

    public GameObject Bomb;

    void Start()
    {
        HpText = GameObject.FindWithTag("HP").GetComponent<Text>();
        Joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        View = GetComponent<PhotonView>();
        if(!View.IsMine)
        {
            Destroy(Body);
            
        }
        else
            HpText.text = $"hp: {HP}";
    }

    public void FixedUpdate()
    {
        if(!View.IsMine)
            return;

        if(HP < 1)
        {
            animator.SetBool("IsDead", true);
            return;
        }

        Body.velocity = new Vector3(
            Joystick.Horizontal * SpeedMove,
            Body.velocity.y,
            Joystick.Vertical * SpeedMove);
        if(Joystick.Horizontal != 0 || Joystick.Vertical != 0)
        {
            Body.rotation = Quaternion.LookRotation(Body.velocity);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag != "Bomb")
            return;

        Destroy(other.gameObject);
        HP -= 20;
        HpText.text = $"hp: {HP}";
    }

    public void Shot()
    {
        if(!View.IsMine)
            return;
        Transform tmp = Instantiate(Bomb).GetComponent<Transform>();
        // tmp.position = transform.position;
        // tmp.eulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        // Debug.Log(tmp.eulerAngles);
    }
}
