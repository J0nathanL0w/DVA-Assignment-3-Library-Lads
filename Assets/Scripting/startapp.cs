using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startapp : MonoBehaviour
{
    public GameObject mainMenu;
    // Start is called before the first frame update
    void StartApp()
    {
        
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
    }

}
