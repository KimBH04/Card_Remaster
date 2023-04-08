using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> remain;
    private List<GameObject> stack;

    public GameObject Draw
    {
        get
        {
            var card = remain[Random.Range(0, stack.Count)];
            stack.RemoveAt(0);
            return card;
        }
    }

    public void Place(GameObject card)
    {
        stack.Add(card);
    }


}
