using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ChatGPT Made this code
/*How to set it up in Unity:
Create the first button and assign ClickMe() to its OnClick() event.

Create the other buttons you want to appear later, and disable them initially (uncheck them in the Inspector).

Attach this script to a GameObject.

In the Inspector:

Assign the "delayed" buttons to the buttonsToShow array.

Set the delay to however many seconds you want.
*/

public class Button_test : MonoBehaviour
{
    public GameObject[] buttonsToShow;
    public float delay = 3f;
    public float fadeDuration = 1f;

    private bool hasBeenPressed = false; // Tracks whether the button has already been clicked

    public void ClickMe()
    {
        if (hasBeenPressed) return; // Do nothing if already pressed
        hasBeenPressed = true;      // Mark as pressed

        Debug.Log("Hello World!");
        StartCoroutine(ShowButtonsAfterDelay());
    }

    private IEnumerator ShowButtonsAfterDelay()
    {
        foreach (GameObject btn in buttonsToShow)
        {
            btn.SetActive(false);
        }

        yield return new WaitForSeconds(delay);

        foreach (GameObject btn in buttonsToShow)
        {
            btn.SetActive(true);

            CanvasGroup canvasGroup = btn.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = btn.AddComponent<CanvasGroup>();

            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn(canvasGroup));
        }
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}