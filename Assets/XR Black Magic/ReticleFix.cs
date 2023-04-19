using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReticleFix : MonoBehaviour
{
    public XRInteractorLineVisual recipient;
    public XRRayInteractor observed;
    public MeshRenderer teleportArea;
    public GameObject teleportObject;

    private void Awake()
    {
        if (teleportObject != null)
        {
            teleportObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!observed.enabled) {
            recipient.reticle.SetActive(false);
            recipient.blockedReticle.SetActive(false);
            if (teleportObject != null)
            {
                teleportObject.SetActive(false);
            }
            if (teleportArea != null)
                teleportArea.enabled = false;
        } else
        {
            if (teleportObject != null)
            {
                teleportObject.SetActive(false);
            }
            if (teleportArea != null)
                teleportArea.enabled = true;
        }
    }
}
