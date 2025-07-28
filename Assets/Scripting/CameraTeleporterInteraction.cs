using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script added by Jonathan Low created using ChatGPT 28/7/2025
 * To make the script work, you need to attach it to the main camera and then insert main camera into the button interaction, the index thing starts at 0 so if your location in the script is the 5 one
 * then the correct placement of it is teleport to index 4 on the button itself.
 */
public class CameraTeleporterInteraction : MonoBehaviour
{
    public Transform[] teleportPoints; // Assign in Inspector

    private int currentIndex = 0;

    public void TeleportToPoint(int index)
    {
        if (teleportPoints != null && index >= 0 && index < teleportPoints.Length)
        {
            transform.position = teleportPoints[index].position;
            transform.rotation = teleportPoints[index].rotation;
            currentIndex = index;
            Debug.Log("I have executed the command");
        }
    }

    // Example: cycle through points
    public void TeleportToNext()
    {
        int nextIndex = (currentIndex + 1) % teleportPoints.Length;
        TeleportToPoint(nextIndex);
    }
}
