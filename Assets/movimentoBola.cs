using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoBola : MonoBehaviour
{
    [Range(5,25)]
    public float velocidade = 10.0f;

    private Vector3 direcao;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        direcao = new Vector3(direcao.x, -direcao.y).normalized;

    }


    void Start()
    {
        float x = Random.Range(-5.0f,5.0f);
        float y = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(x, y).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao*Time.deltaTime*velocidade;
        
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if( posicaoViewport.x < 0.02 || posicaoViewport.x > 0.98 )
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if( posicaoViewport.y < 0.02 || posicaoViewport.y > 0.98 )
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }

    }
}
