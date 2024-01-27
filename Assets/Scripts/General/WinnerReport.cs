using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinnerReport : MonoSingleton<WinnerReport>
{
    public bool ifP1won;
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
