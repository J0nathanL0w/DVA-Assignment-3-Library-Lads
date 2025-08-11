using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkUrl : MonoBehaviour
{
    public string url = "https://www.example.com";

    public void Open()
    {
        Application.OpenURL(url);
    }
}
