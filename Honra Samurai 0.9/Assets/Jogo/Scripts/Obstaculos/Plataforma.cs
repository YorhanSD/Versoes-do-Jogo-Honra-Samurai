using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private bool moveBaixo = true;
    public float velocidade = 3f;
    public Transform pontoA;
    public Transform pontoB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(transform.position.y > pontoA.position.y)
        moveBaixo = true;
         if(transform.position.y < pontoB.position.y)
        moveBaixo = false;
        if(moveBaixo)
        transform.position = new Vector2(transform.position.x,transform.position.y - velocidade * Time.deltaTime);
        else
        transform.position = new Vector2(transform.position.x,transform.position.y + velocidade * Time.deltaTime);
        
    }
}
