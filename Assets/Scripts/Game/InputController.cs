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
        Joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        Button = GameObject.FindWithTag("Button").GetComponent<Button>();
        View = GetComponent<PhotonView>();
        NickName.text = "Враг";
        if(View.IsMine)
        {
            HpText = GameObject.FindWithTag("HP").GetComponent<Text>();
            NickName.text = "Ты";
            Button.onClick.AddListener(Shot);
            HpText.text = $"hp: {HP}";
        }
        WinController.instanse.PlayerConnect(NickName.text);
    }

    public void FixedUpdate()
    {
        if(HP < 1)
        {
            animator.SetBool("IsDead", true);
            WinController.instanse.PlayerIsDied(NickName.text);
            return;
        }

        if(!View.IsMine)
            return;

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

        if(HP < 1)
            return;

        Destroy(other.gameObject);
        HP -= 20;

        if(View.IsMine)
            HpText.text = $"hp: {HP}";
    }

    public void Shot()
    {
        if(!View.IsMine)
            return;
        if(HP < 1)
            return;
        transform.Translate(0, 0, 1);
        Vector3 tmp = transform.position;
        transform.Translate(0, 0, -1);
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "Bomb"),
            tmp,
            transform.rotation);
    }

    public void UpdateHP(int value)
    {
        if(HP > 99)
            return;
        HP += value;

        if(View.IsMine)
            HpText.text = $"hp: {HP}";
    }
}
