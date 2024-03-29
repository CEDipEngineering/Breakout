using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoBola : MonoBehaviour
{
    [Range(5,25)]
    public float velocidade = 10.0f;

    private Vector3 direcao;
    GameManager gm;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        direcao = new Vector3(direcao.x, -direcao.y).normalized;
        if (col.gameObject.CompareTag("Brick"))
        {
            gm.pontos++;
        }
    }

    public void ResetPosition() 
    {  
        transform.position = new Vector3(0,-3.5f,0);
    }

    void Start()
    {
        float x = Random.Range(-5.0f,5.0f);
        float y = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(x, y).normalized;
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += ResetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        transform.position += direcao*Time.deltaTime*velocidade;
        
        // Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if( posicaoViewport.x < 0.02 || posicaoViewport.x > 0.98 )
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if(posicaoViewport.y > 0.98 )
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        if (posicaoViewport.y < 0.02)
        {
            Reset();
        }

    }

    private void Reset()
    {
        gm.vidas--;
        if (gm.vidas <=0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        } else {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = playerPosition + new Vector3(0,0.5f,0);
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(2.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
    }
}
