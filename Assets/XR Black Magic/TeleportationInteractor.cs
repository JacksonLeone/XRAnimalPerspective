using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class TeleportationInteractor : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actionAsset;
    [SerializeField]
    private XRRayInteractor rayInteractor;
    [SerializeField]
    private TeleportationProvider provider;

    [SerializeField]
    InputActionProperty m_TeleportActivate;
    public InputActionProperty teleportActivate
    {
        get => m_TeleportActivate;
        set => SetInputActionProperty(ref m_TeleportActivate, value);
    }

    [SerializeField]
    InputActionProperty m_TeleportCancel;
    public InputActionProperty teleportCancel
    {
        get => m_TeleportCancel;
        set => SetInputActionProperty(ref m_TeleportCancel, value);
    }

    [SerializeField]
    InputActionProperty m_TeleportSelect;
    private bool isActive;

    public InputActionProperty teleportSelect
    {
        get => m_TeleportSelect;
        set => SetInputActionProperty(ref m_TeleportSelect, value);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide line at start
        rayInteractor.enabled = false;

        //teleportActivate.EnableDirectAction();
        teleportActivate.action.Enable();
        teleportActivate.action.performed += OnTeleportActivate;
        //teleportCancel.EnableDirectAction();
        teleportCancel.action.Enable();
        teleportCancel.action.performed += OnTeleportCancel;
        //teleportSelect.EnableDirectAction();
        teleportSelect.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (teleportSelect.action.ReadValue<Vector2>() != Vector2.zero)
        {
            return;
        }

        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        isActive = false;
    }

    void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        isActive = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        isActive = false;
    }

    // Stoel from ActionBasedController.cs
    void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
    {
        if (Application.isPlaying)
            property.DisableDirectAction();

        property = value;

        if (Application.isPlaying && isActiveAndEnabled)
            property.EnableDirectAction();
    }
}
