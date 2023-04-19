using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameModeSwap : MonoBehaviour
{
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
        }
        else
        {
            vrPlayer.SetActive(false);
            desktopPlayer.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (inVR)
        {
            text.text = "Desktop Mode";
        } else
        {
            text.text = "VR Mode";
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
        } else
        {
            vrPlayer.transform.position = desktopPlayer.transform.position + new Vector3(0, 0.5f, 0);
            vrPlayer.transform.rotation = desktopPlayer.transform.rotation;
            vrPlayer.SetActive(true);
            desktopPlayer.SetActive(false);
            inVR = true;
        }
    }
}
