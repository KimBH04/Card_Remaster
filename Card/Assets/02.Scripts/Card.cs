using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private CardStack stack;

    private string cardName;
    private char cardSuits;
    private int cardNumber;

    public string Name => cardName;
    public char Suit => cardSuits;
    public int Number => cardNumber;

    private void Awake()
    {
        stack = GameObject.Find("CardManager").GetComponent<CardStack>();

        cardName = name;
        cardSuits = cardName[0];
        cardNumber = int.Parse(cardName[1..]);
        //print($"{Name} {Suit} {Number}");
    }

    private void OnMouseDown()
    {
        stack.Place(gameObject);
        Destroy(gameObject);
    }
}
