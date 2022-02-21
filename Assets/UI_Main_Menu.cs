using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_Menu : MonoBehaviour
{
    
    GameManager gm;
    // Start is called before the first frame update
    void OnEnable() 
    {
        gm = GameManager.GetInstance();
    }
    
    public void begin()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
