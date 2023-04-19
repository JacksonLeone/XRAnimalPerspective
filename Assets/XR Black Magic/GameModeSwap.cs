using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSwap : MonoBehaviour
{
    public GameObject desktopPlayer;
    public GameObject vrPlayer;
    public bool inVR = true;

    public void ChangeGameMode()
    {
        if (inVR)
        {
            desktopPlayer.transform.position = vrPlayer.transform.position;
            desktopPlayer.transform.rotation = vrPlayer.transform.rotation;
            vrPlayer.SetActive(false);
            desktopPlayer.SetActive(true);
            inVR = false;
        } else
        {
            vrPlayer.transform.position = desktopPlayer.transform.position;
            vrPlayer.transform.rotation = desktopPlayer.transform.rotation;
            vrPlayer.SetActive(true);
            desktopPlayer.SetActive(false);
            inVR = true;
        }
    }
}
