using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> remain;
    private Stack<Card> stack;

    [SerializeField]
    private GameManager manager;

    private bool mustGetCard;

    public GameObject Draw
    {
        get
        {
            int idx = Random.Range(0, remain.Count);
            var card = remain[idx];
            remain.RemoveAt(idx);
            return card;
        }
    }

    public void Place(GameObject @object, Card card, bool turn, bool consecutive)
    {
        Card stacked = stack.Peek();
        int s_number = stacked.Number;
        char s_suit = stacked.Suit;
        char s_color = stacked.Color;

        int p_number = card.Number;
        char p_suit = card.Suit;
        char p_color = card.Color;

        if (mustGetCard)
        {
            if (p_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowCard(p_color, 14);
                }
                else if (s_suit == 'J' && s_color == 'b')
                {
                    if (p_color == 'r')
                    {
                        ThrowCard('r', 14);
                    }
                    else if (p_suit == 'S' && p_number == 4)
                    {
                        ThrowCard('r', 4);
                    }
                }
            }
            else if (p_suit == s_suit && consecutive)
            {
                if (p_number == 1 && s_number == 2)
                {
                    ThrowCard(p_suit, p_number);
                }

            }
            else if (p_number == s_number)
            {
                ThrowCard(p_suit, p_number);
            }
        }
        else
        {
            if (p_suit == s_suit && consecutive)
            {
                ThrowCard(p_suit, p_number);
            }
            else if (p_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowCard(p_color, 14);
                }
                else if (s_suit == 'J' && s_color == 'b' && p_color == 'r')
                {
                    ThrowCard('r', 14);
                }
            }
            else if (s_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowCard(p_suit, p_number);
                }
            }
            else if (p_number == s_number)
            {
                ThrowCard(p_suit, p_number);
            }
        }
    }

    private void ThrowCard(char suit, int number)
    {
        if (number == 1)
        {
            manager.CardsStack += suit.Equals('S') ? 5 : 3;
        }
        else if (number == 2)
        {
            manager.CardsStack += 2;
        }
        else if (number == 14)
        {
            manager.CardsStack += suit.Equals('r') ? 7 : 10;
        }


    }
}
