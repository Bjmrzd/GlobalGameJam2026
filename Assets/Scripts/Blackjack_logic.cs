using UnityEngine;
using System;

public class Blackjack_logic : MonoBehaviour
{
    public enum Cards_deck
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }
    public enum Color
    {
        Spades = 1,
        Diamonds,
        Clubs,
        Hearts,

    }

    public class Cards
    {
        public Cards_deck cards;

        public Color Suits;


        public int Points;

        private static System.Random value = new System.Random();
        public void Get_value()
        {
            cards = (Cards_deck)value.Next(2, 15);
            Suits = (Color)value.Next(0, 4);
            Score();
        }
        public int Score()
        {

            if ((int)cards <= 10)
            {
                Points = (int)cards;
                return Points;
            }
            else if (cards == Cards_deck.Ace)
            {
                Points = 11;
                return Points;
            }
            else
            {
                Points = 10;
                return Points;
            }
        }
    }


    public class Game
    {
        public int round;
        public bool end_of_round = false;



        public void init_round()
        {
            round = 0;
            if (end_of_round == true)
            {
                round++;
                end_of_round = false;

            }

        }

    }
}

