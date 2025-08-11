using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFreezing : MonoBehaviour
{
    public CameraMovement cameraLookScript; // Drag your camera look script here in the Inspector
    public Button freezeButton;         // Button to freeze camera
    public Button unfreezeButton;       // Button to unfreeze camera

    void Start()
    {
        freezeButton.onClick.AddListener(FreezeCamera);
        unfreezeButton.onClick.AddListener(UnfreezeCamera);

        // Start in frozen state
        FreezeCamera();
    }

    public void FreezeCamera()
    {
        if (cameraLookScript != null)
            cameraLookScript.enabled = false;

        Cursor.lockState = CursorLockMode.None; // Free the mouse
        Cursor.visible = true;                  // Show the mouse
    }

    public void UnfreezeCamera()
    {
        if (cameraLookScript != null)
            cameraLookScript.enabled = true;

        Cursor.lockState = CursorLockMode.None; // Keep the mouse free
        Cursor.visible = true;                  // Keep the mouse visible
    }
}
