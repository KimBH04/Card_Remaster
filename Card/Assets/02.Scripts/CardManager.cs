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
        int p_number = card.Number;
        char p_suit = card.Suit;
        char p_color = card.Color;

        Card stacked = stack.Peek();
        int s_number = stacked.Number;
        char s_suit = stacked.Suit;
        char s_color = stacked.Color;

        if (mustGetCard)
        {
            if (p_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowACard(p_color, 14);
                }
                else if (s_suit == 'J' && s_color == 'b')
                {
                    if (s_color == 'r')
                    {
                        ThrowACard('r', 14);
                    }
                    else if (p_suit == 'S' && p_number == 4)
                    {
                        ThrowACard('r', 4);
                    }
                }
            }
            else if (p_suit == s_suit && consecutive)
            {
                if (p_number == 1 && s_number == 2)
                {
                    ThrowACard(p_suit, p_number);
                }

            }
            else if (p_number == s_number)
            {
                ThrowACard(p_suit, p_number);
            }
        }
        else
        {
            if (p_suit == s_suit && consecutive)
            {
                ThrowACard(p_suit, p_number);
            }
            else if (p_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowACard(p_color, 14);
                }
                else if (s_suit == 'J' && s_color == 'b' && p_color == 'r')
                {
                    ThrowACard('r', 14);
                }
            }
            else if (s_suit == 'J')
            {
                if (p_color == s_color && consecutive)
                {
                    ThrowACard(p_suit, p_number);
                }
            }
            else if (p_number == s_number)
            {
                ThrowACard(p_suit, p_number);
            }
        }
    }

    private void ThrowACard(char suit, int number)
    {

    }
}
