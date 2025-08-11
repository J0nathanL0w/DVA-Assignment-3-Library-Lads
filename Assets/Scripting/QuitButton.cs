using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // This method can be called from a UI Button's OnClick event
    public void Quit()
    {
        Debug.Log("Quit Game triggered");

        // Quits the application (only works in a built game)
        Application.Quit();

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
