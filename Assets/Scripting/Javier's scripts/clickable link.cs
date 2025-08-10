using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HyperLink : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text pTextMeshPro = GetComponent<TMP_Text>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, Camera.main);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            if (linkInfo.GetLinkID() == "debug")
            {
                Debug.Log("link clicked");
            }
            else
            {
                Application.OpenURL(linkInfo.GetLinkID());
            }
        }
    }
}