using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameModeSwap : MonoBehaviour
{
    public Vector3 spawnLocation;
    public TextMeshProUGUI text;
    public GameObject desktopPlayer;
    public GameObject vrPlayer;
    public bool inVR = true;

    private void Start()
    {
        if (inVR)
        {
            vrPlayer.SetActive(true);
            desktopPlayer.SetActive(false);
            UpdateText();
        }
        else
        {
            vrPlayer.SetActive(false);
            desktopPlayer.SetActive(true);
            UpdateText();
        }

        vrPlayer.transform.position = spawnLocation;
        desktopPlayer.transform.position = spawnLocation;
    }

    private void UpdateText()
    {
        if (inVR)
        {
            text.text = "Switch to desktop";
        } else
        {
            text.text = "Switch to VR";
        }
    }

    public void ChangeGameMode()
    {
        if (inVR)
        {
            desktopPlayer.transform.position = vrPlayer.transform.position + new Vector3(0, 0.5f, 0);
            desktopPlayer.transform.rotation = vrPlayer.transform.rotation;
            vrPlayer.SetActive(false);
            desktopPlayer.SetActive(true);
            inVR = false;
            UpdateText();
        } else
        {
            vrPlayer.transform.position = desktopPlayer.transform.position + new Vector3(0, 0.5f, 0);
            vrPlayer.transform.rotation = desktopPlayer.transform.rotation;
            vrPlayer.SetActive(true);
            desktopPlayer.SetActive(false);
            inVR = true;
            UpdateText();
        }
    }
}
