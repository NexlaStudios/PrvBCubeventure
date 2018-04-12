using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour {
    
    [Header("References")]
    [SerializeField] GameObject inv;
    [SerializeField] GameObject paus;

    enum Menus { normal , pause , inv};
    Menus currentMenu = Menus.normal;
    string lastScreen = "normal";

    void Start()
    {
        inv.SetActive(false);
        paus.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        OpenInventory();
        OpenPause();
        SetScreen();
	}

    void SetScreen()
    {
        if(currentMenu != Menus.normal)
        {
            if(currentMenu == Menus.inv)
            {
                inv.SetActive(true);
                paus.SetActive(false);
            } else if(currentMenu == Menus.pause)
            {
                paus.SetActive(true);
            }
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
            inv.SetActive(false);
            paus.SetActive(false);
        }

    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && currentMenu != Menus.pause)
        {
            if (currentMenu == Menus.inv)
            {
                lastScreen = "normal";
                currentMenu = Menus.normal;
            }
            else
            {
                lastScreen = "inv";
                currentMenu = Menus.inv;
            }
        }
    }

    void OpenPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentMenu == Menus.normal)
            {
                lastScreen = "normal";
                currentMenu = Menus.pause;

            } else if(currentMenu == Menus.inv)
            {
                lastScreen = "inv";
                currentMenu = Menus.pause;
            } else
            {
                SetToLastScreen();
                lastScreen = "pause";
            }
        }
    }

    void SetToLastScreen()
    {
        switch (lastScreen)
        {
            case "normal":
                currentMenu = Menus.normal;
                break;
            case "inv":
                currentMenu = Menus.inv;
                break;
            default:
                break;
        }
    }


}
