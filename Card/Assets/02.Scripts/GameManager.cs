using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DrawCard;

    private bool isPlayerTurn = true;
    private int getCardsStack;

    public bool PlayerTurn => isPlayerTurn;
    public int CardsStack
    {
        get
        {
            return getCardsStack;
        }
        set
        {
            getCardsStack = value;
        }
    }

    IEnumerator Start()
    {
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitForSeconds(.3f);

            GameObject temp = Instantiate(DrawCard, transform.position, Quaternion.Euler(new(180f, 0f)));
            temp.GetComponent<Rigidbody>().AddForce(new(0f, 0f, i % 2 == 0 ? -75f : 75f));
            Destroy(temp, 1f);
        }
    }
}
