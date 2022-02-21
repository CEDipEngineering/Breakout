using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoRaquete : MonoBehaviour
{
    [Range(1,15)]
    public float velocidade = 10.0f;
    // Start is called before the first frame update
    public GameManager gm;
    
    public void ResetPosition()
    {
        transform.position = new Vector3(0,-4.0f,0);
    }
    
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += ResetPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if(gm.gameState != GameManager.GameState.GAME) return;
        float inputX = Input.GetAxis("Horizontal");
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if(posicaoViewport.x > 0.05 && posicaoViewport.x < 0.95)
        {
            transform.position += new Vector3(inputX,0,0)*Time.deltaTime*velocidade;
        }
        if(posicaoViewport.x < 0.05 && inputX>0)
        {
            transform.position += new Vector3(inputX,0,0)*Time.deltaTime*velocidade;
        }
        if(posicaoViewport.x > 0.95 && inputX<0)
        {
            transform.position += new Vector3(inputX,0,0)*Time.deltaTime*velocidade;
        }


        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

    }
}
