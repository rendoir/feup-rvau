using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public Teleport teleport;
    public Locomotion locomotion;
    private bool isLocomotionActive;
    private TeleportMarkerBase[] teleportMarkers;
    public SteamVR_Action_Boolean teleportToggle = null;

    void Start()
    {
        isLocomotionActive = false;
        teleportMarkers = teleport.GetComponentsInChildren<TeleportMarkerBase>();
        teleportToggle.AddOnStateUpListener(HandleLocomotionChange, SteamVR_Input_Sources.Any);
        ToggleMovement();
    }

    private void Update()
    {
        Teleport.instance.CancelTeleportHint();
    }

    void HandleLocomotionChange(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        ToggleMovement();
    }

    void ToggleMovement()
    {
        // Reset speed
        if (locomotion.enabled)
            locomotion.StopMoving();

        teleport.enabled = isLocomotionActive;
        locomotion.enabled = !isLocomotionActive;
        foreach (TeleportMarkerBase marker in teleportMarkers)
        {
            marker.gameObject.SetActive(isLocomotionActive);
        }
        isLocomotionActive = !isLocomotionActive;
    }
}
