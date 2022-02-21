using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Brick;    
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construct;
        Construct();
    }

    void Construct(){
        if(gm.gameState == GameManager.GameState.GAME){
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child);
            }
            for(int i = 4; i < 8; i++)
            {
                for(int j = 1; j < 3; j++)
                {
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    Instantiate(Brick, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
            {
                gm.ChangeState(GameManager.GameState.ENDGAME);
            }
    }
}
