using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.
using UnityEngine.UI;

public class LoadGame : MonoBehaviour, IPointerDownHandler
{
     public void OnPointerDown(PointerEventData eventData)
    {
        Application.LoadLevel("GameBoard");
    }
}
