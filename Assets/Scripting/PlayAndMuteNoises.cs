using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * How to Set Up in Unity:
Create an empty GameObject (or attach to a UI Button).
Attach this script to it.

Drag your AudioSource for the sound you want to play into Sound To Play.

Drag the AudioSources you want muted into Sounds To Mute.

If using a UI Button:

Select the button.

In the OnClick() list, add your GameObject with the script.

Select PlayAndMute.PlayAndMuteOthers() from the dropdown.

 Notes:

This method mutes rather than stopping — so the muted sounds keep their play position but are inaudible.

If you want to completely stop those other sounds, replace:

csharp
Copy
Edit
sound.mute = true;
with:

csharp
Copy
Edit
sound.Stop();
You can easily extend this to unmute everything later by adding another function.
 */

public class PlayAndMuteNoises : MonoBehaviour
{
    [Header("Sound to Play")]
    public AudioSource soundToPlay;

    [Header("Sounds to Mute")]
    public AudioSource[] soundsToMute;

    // Call this method from a button or event
    public void PlayAndMuteOthers()
    {
        // 1. Mute chosen sounds
        foreach (AudioSource sound in soundsToMute)
        {
            if (sound != null)
            {
                sound.mute = true;
            }
        }

        // 2. Play the target sound
        if (soundToPlay != null)
        {
            soundToPlay.mute = false; // Ensure it's unmuted
            soundToPlay.Play();
        }
    }
}
