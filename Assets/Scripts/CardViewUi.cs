using UnityEngine;
using UnityEngine.EventSystems;



public class CardViewUI : MonoBehaviour, IPointerClickHandler
{
    public int cardValue;
    public bool isPlayerCard;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked card value: " + cardValue);
    }
}


