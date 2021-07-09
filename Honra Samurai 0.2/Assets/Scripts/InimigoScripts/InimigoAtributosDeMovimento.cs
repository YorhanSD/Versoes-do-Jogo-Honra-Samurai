using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtributosDeMovimento : MonoBehaviour
{
    public float velocidadeDoInimigo = 4f;
    public int distanciaDoPlayerNoEixoX = 8;
    public int distanciaDoPlayerNoEixoY = 5;
    public GameObject inimigo;
    public Transform espada;
    private bool ladoDireito = false; 
    public bool chamarAtacando;
    public bool chamarSendoAtacado;
    private Transform player;
    private Rigidbody2D rigid;
    private Animator anim;
    public SpriteRenderer sprite;
    private Transform posicaoDoPlayer;
    private Vector3 distanciaDoPlayer;
  
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
        posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {   
        //pega o componente "atacando" do script "InimigoAtributosDeAtaque"
        chamarAtacando = GetComponent<InimigoAtributosDeAtaque>().atacando;  
        chamarSendoAtacado = GetComponent<InimigoControleDeDano>().sendoAtacado;

        distanciaDoPlayer = posicaoDoPlayer.transform.position - transform.position;
        //verifica a distancia do player no eixo x y e z
        //"mathf.abs" serve para transformar o valor em absoluto para essa distancia valer tanto na direita como na esquerda
        //se a distancia do player for menor que 8 no eixo x e 5 no eixo y então:
        if(chamarAtacando == false && chamarSendoAtacado == false)
        {
            if (Mathf.Abs(distanciaDoPlayer.x) < distanciaDoPlayerNoEixoX && Mathf.Abs(distanciaDoPlayer.y) < distanciaDoPlayerNoEixoY )
              {
                //inimigo se move em direcao ao player
                  rigid.velocity = new Vector2(velocidadeDoInimigo * (distanciaDoPlayer.x / Mathf.Abs(distanciaDoPlayer.x)),rigid.velocity.y);
               
              }
        }

        //Pega a velocidade do Animator
        anim.SetFloat("velocidadeDoInimigo", Mathf.Abs(rigid.velocity.x));
       
        //Se a velocidade do inimigo for maior que zero entao:
        if(rigid.velocity.x > 0 && !ladoDireito)
        {
         //Flip sprite
         Flip();
        }
         //Se a velocidade do inimigo for menor que zero entao:
         else if(rigid.velocity.x < 0 && ladoDireito)
        {
         //Flip sprite
         Flip();
        }
        
    }
    void Flip()
    {
      //Flipar o inimigo
      ladoDireito = !ladoDireito;
      //Flipar Espada
      espada.localPosition = new Vector2(-espada.localPosition.x, espada.localPosition.y);
    }
    

}
