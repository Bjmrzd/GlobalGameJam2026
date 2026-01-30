

using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Blackjack_logic : MonoBehaviour
{

    public GameObject cardPrefab;
    public Transform playerCardArea;
    public Transform dealerCardArea;
    public enum Cards_deck { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum Color { Spades, Diamonds, Clubs, Hearts }

    public class Cards
    {
        public Cards_deck cards;
        public Color Suits;
        public int Points;





        public void Get_value()
        {
            cards = (Cards_deck)Random.Range(2, 15);
            Suits = (Color)Random.Range(0, 4);
            Points = Score();
        }

        public int Score()
        {
            if ((int)cards <= 10) return (int)cards;
            else if (cards == Cards_deck.Ace) return 11;
            else return 10;
        }
    }

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI dealerScoreText;
    public TextMeshProUGUI resultText;
    public GameObject blackjackUI;
    public DialogueManager dialogueManager;

    private List<Cards> playerHand = new List<Cards>();
    private List<Cards> dealerHand = new List<Cards>();
    private int playerScore = 0;
    private int dealerScore = 0;
    private bool playerTurn = true;

    private bool gameOver = false;


    void Start()
    {
        blackjackUI.SetActive(true);
    }

    public void StartBlackjack()
    {
        resultText.text = "";
        blackjackUI.SetActive(true);
        playerHand.Clear();
        dealerHand.Clear();
        playerScore = 0;
        dealerScore = 0;
        playerTurn = true;
        DrawCard(true);
        DrawCard(true);
        DrawCard(false);
    }

    public void DrawCard(bool isPlayer)
    {
        if (!playerTurn || gameOver) return;
        Cards newCard = new Cards();
        newCard.Get_value();

        Transform area = isPlayer ? playerCardArea : dealerCardArea;


        GameObject cardGO = Instantiate(cardPrefab, area);
        cardGO.transform.localScale = Vector3.one;


        CardViewUI view = cardGO.GetComponent<CardViewUI>();
        view.cardValue = newCard.Points;
        view.isPlayerCard = isPlayer;


        Sprite sprite = GetSpriteForCard(newCard.cards, newCard.Suits);
        view.SetCardSprite(sprite);


        if (isPlayer)
        {
            playerHand.Add(newCard);
            playerScore += newCard.Points;
            playerScoreText.text = "Joueur: " + playerScore;
            if (playerScore > 21) EndTurn();
        }
        else
        {
            dealerHand.Add(newCard);
            dealerScore += newCard.Points;
            dealerScoreText.text = "Croupier: " + dealerScore;
        }
    }


    public void EndTurn()
    {
        playerTurn = false;
        while (dealerScore < 17)
            DrawCard(false);
        CheckWinner();
    }

    public void CheckWinner()
    {

        if (playerScore > 21 || (dealerScore <= 21 && dealerScore > playerScore))
        {
            resultText.text = "Le croupier gagne !";

        }
        else if (dealerScore > 21 || playerScore > dealerScore)
        {
            resultText.text = "Tu gagnes !";

        }
        else
        {
            resultText.text = "Égalité !";

        }
        gameOver = true;

    }

    public void RestartGame()
    {
        resultText.text = "";
        StartBlackjack();
    }

    public void QuitBlackjack()
    {
        blackjackUI.SetActive(false);
        dialogueManager.DisplayNextSentence();
    }

    Sprite GetSpriteForCard(Cards_deck value, Color suit)
    {
        string name = value.ToString().ToLower() + "_of_" + suit.ToString().ToLower();
        return Resources.Load<Sprite>("Sprites/Cards/" + name);
    }

}


