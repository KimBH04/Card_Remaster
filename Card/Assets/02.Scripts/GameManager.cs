using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlayerTurn = true;

    public bool PlayerTurn => isPlayerTurn;
}
