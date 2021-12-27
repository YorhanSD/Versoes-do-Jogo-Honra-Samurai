using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerraHorizontalControle : MonoBehaviour
{
    private bool moveDireita = true;
    public int danoCerra = 100;
    public float velocidade = 7f;
    public Transform pontoA;
    public Transform pontoB;

    
    void Start()
    {
        
    }

    
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
