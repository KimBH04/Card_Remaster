using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public You you;
    private GameManager manager;
    private CardManager cardManager;

    private string cardName;
    private char cardSuits;
    private int cardNumber;

    private char cardColor;

    public string Name => cardName;
    public char Suit => cardSuits;
    public int Number => cardNumber;
    public char Color => cardColor;

    void Awake()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        cardName = name;
        cardSuits = cardName[0];
        cardNumber = int.Parse(cardName[1..]);

        cardColor = cardSuits == 'S' || cardSuits == 'C' ? 'b' : 'r';
        //print($"{Name} {Suit} {Number}");
    }

    void OnMouseDown()
    {
        if (manager.PlayerTurn)
        {
            cardManager.Place(gameObject, this, true, you.Consecutive);
        }
    }
}
