using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LinkController : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI linkText;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            int index = TMP_TextUtilities.FindIntersectingLink(linkText, eventData.position, null);
            Debug.Log(TMP_TextUtilities.FindIntersectingLink(linkText, eventData.position, null));
            if (index > -1)
            {
                Application.OpenURL(linkText.textInfo.linkInfo[index].GetLinkID());
            }
        }
    }
}
