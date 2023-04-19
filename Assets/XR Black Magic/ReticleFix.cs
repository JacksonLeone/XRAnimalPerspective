using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReticleFix : MonoBehaviour
{
    public XRInteractorLineVisual recipient;
    public XRRayInteractor observed;
    public MeshRenderer teleportArea;

    // Update is called once per frame
    void Update()
    {
        if (!observed.enabled) {
            recipient.reticle.SetActive(false);
            recipient.blockedReticle.SetActive(false);
            teleportArea.enabled = false;
        } else
        {
            teleportArea.enabled = true;
        }
    }
}
