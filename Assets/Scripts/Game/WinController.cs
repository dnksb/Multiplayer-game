using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public static WinController instanse;

    public GameObject ShowWin;
    public GameObject Controllers;
    public Text WinText;
    public List<string> Players;

    void Start()
    {
        instanse = this;
    }

    public void PlayerConnect(string name)
    {
        Players.Add(name);
    }

    public void PlayerIsLeave(string name)
    {
        Players.Remove(name);
    }

    public void PlayerIsDied(string name)
    {
        Players.Remove(name);
        if(Players.Count == 1)
        {
            ShowWin.SetActive(true);
            Controllers.SetActive(false);
            WinText.text = $"Победил {Players[0]}";
        }
    }

    public void Quit()
    {
        Application.LoadLevel("Lobby");
    }
}
