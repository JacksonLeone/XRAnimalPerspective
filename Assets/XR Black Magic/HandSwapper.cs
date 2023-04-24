using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class HandSwapper : MonoBehaviour
{
    public GameObject teleportHand;
    public GameObject normalHand;

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
        // Start normal
        normalHand.SetActive(true);
        teleportHand.SetActive(false);

        teleportActivate.action.Enable();
        teleportActivate.action.performed += BeginTeleport;
        teleportCancel.action.Enable();
        teleportCancel.action.performed += EndTeleport;
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

        normalHand.SetActive(true);
        teleportHand.SetActive(false);
        isActive = false;
    }

    void BeginTeleport(InputAction.CallbackContext context)
    {
        normalHand.SetActive(false);
        teleportHand.SetActive(true);
        isActive = true;
    }

    void EndTeleport(InputAction.CallbackContext context)
    {
        normalHand.SetActive(true);
        teleportHand.SetActive(false);
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
