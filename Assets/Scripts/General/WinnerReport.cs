using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinnerReport : MonoSingleton<WinnerReport>
{
    public bool ifP1won;

    public GameObject pannal1_winner;
    public GameObject pannal2_winner;

    private void OnTriggerEnter2D(Collider2D col)
    {
        string crs = col.ToString();
        if (col.CompareTag("Player") && col.gameObject.ToString()=="player1 (UnityEngine.GameObject)")
        {
            Debug.Log("Player1 is win");
            pannal1_winner.SetActive(true);
        }
        else if (col.CompareTag("Player") && col.gameObject.ToString() == "player2 (UnityEngine.GameObject)")
        {
            Debug.Log("Player2 is win");
            pannal2_winner.SetActive(true);
        }
    }

    public void checkWinner()
    {
        if (PlayerController.Instance.getIsStage())
        {
            ifP1won = true;
        }
        else if(PlayerTwoController.Instance.getIsStage()) 
        {
            ifP1won= false;
        }
    }
}
