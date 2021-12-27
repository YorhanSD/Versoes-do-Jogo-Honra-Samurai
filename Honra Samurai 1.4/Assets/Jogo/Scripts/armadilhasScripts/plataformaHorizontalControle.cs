using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaHorizontalControle : MonoBehaviour
{
    private bool moveDireita = true;
    public float velocidade = 8f;
    public Transform pontoA;
    public Transform pontoB;
   
    void Update()
    {
         if(transform.position.x < pontoA.position.x)
        moveDireita = true;
         if(transform.position.x > pontoB.position.x)
        moveDireita = false;
        if(moveDireita)
        transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y );
        else
        transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y );
        
    }
}
