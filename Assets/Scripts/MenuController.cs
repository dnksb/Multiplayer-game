using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public static MenuController instanse;

    public void Start()
    {
        instanse = this;
    }

    public List<Menu> menus;

    public void Open(string nameMenu)
    {
        foreach (Menu item in menus)
        {
            if(item.NameMenu == nameMenu)
                item.Open();
            else
                item.Close();
        }
    }
}
