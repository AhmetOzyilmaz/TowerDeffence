using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.
using UnityEngine.UI;

public class Exit : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
        Debug.Log(this.gameObject.name + " Was Clicked.");

    }
}