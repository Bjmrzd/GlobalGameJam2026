using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;





public class CardViewUI : MonoBehaviour, IPointerClickHandler
{
    public int cardValue;
    public bool isPlayerCard;

    public Image cardImage;
    public Sprite frontSprite;
    // public UnityEngine.UI.Image cardImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked card value: " + cardValue);
    }

    public void SetCardSprite(Sprite sprite)
    {
        frontSprite = sprite;
        if (cardImage != null)
            cardImage.sprite = frontSprite;
        else
            Debug.LogWarning("cardImage not assigned in inspector!");
    }
}


