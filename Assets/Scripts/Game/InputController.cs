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

    public Button Button;
    public Text NickName;

    void Start()
    {
        HpText = GameObject.FindWithTag("HP").GetComponent<Text>();
        Joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        Button = GameObject.FindWithTag("Button").GetComponent<Button>();
        View = GetComponent<PhotonView>();
        NickName.text = PhotonNetwork.NickName;
        if(!View.IsMine)
        {
            Destroy(Body);
        }
        else
        {
            Button.onClick.AddListener(Shot);
            HpText.text = $"hp: {HP}";
        }
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
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "Bomb"),
            transform.position,
            transform.rotation);
    }

    public void UpdateHP(int value)
    {
        if(HP > 99)
            return;
        HP += value;
        HpText.text = $"hp: {HP}";
    }
}
