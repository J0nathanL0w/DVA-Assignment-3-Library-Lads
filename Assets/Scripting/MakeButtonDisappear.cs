using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButtonDisappear : MonoBehaviour
{
    public Button myButton;       // Assign in Inspector
    public float hideDelay = 2f;  // Seconds to wait before hiding

    void Start()
    {
        // Hook up the listener
        myButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        // Start the countdown to hide the button
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);

        // Option 1: Disable the button (it stays visible but can’t be clicked)
        // myButton.interactable = false;

        // Option 2: Hide the button completely
        myButton.gameObject.SetActive(false);
    }
}
