using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause : MonoBehaviour
{
    GameManager gm;
    public void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    public void Continue()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
