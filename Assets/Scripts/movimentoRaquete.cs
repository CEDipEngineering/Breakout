using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoRaquete : MonoBehaviour
{
    [Range(1,15)]
    public float velocidade = 10.0f;

    private Vector2 angle = new Vector2(0f,0f);
    // Start is called before the first frame update
    public GameManager gm;
    
    public Vector2 getAngle()
    {
        return angle;
    }

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
        float inputY = Input.GetAxis("Vertical");
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

        if(inputY>0 && Vector2.angle(angle, Vector2.right)<=135)
        {
            angle = Rotate(angle, 1);
        }
        if(inputY<0 && Vector2.angle(angle, Vector2.right)<=45)
        {
            angle = Rotate(angle, -1);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

    }


    public Vector2 Rotate(Vector2 v, float degrees) {
         float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
         float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         return return new Vector2((cos * v.x) - (sin * v.y), (sin * v.x) + (cos * v.y));
     }
}
