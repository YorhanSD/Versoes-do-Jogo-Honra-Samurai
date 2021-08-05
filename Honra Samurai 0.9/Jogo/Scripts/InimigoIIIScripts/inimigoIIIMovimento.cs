using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigoIIIMovimento : MonoBehaviour
{
    public float velocidade = 25f;
    public Slider chamarVida;
    public int distanciaDoPlayerNoEixoX = 50;
    public int distanciaDoPlayerNoEixoY = 50;
    public GameObject inimigo;
    public Transform chaveInglesa;
    public bool chamarPodeAtacar;
    public bool chamarSendoAtacado;
    private Transform player;
    private Rigidbody2D rigid;
    public Animator anim;
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
        chamarSendoAtacado = GetComponent<InimigoIIIControleDeDano>().sendoAtacado;
        chamarPodeAtacar = GetComponent<InimigoIIIAtaque>().podeAtacar;
        chamarVida = GetComponent<InimigoIIIControleDeDano>().vida;

        distanciaDoPlayer = posicaoDoPlayer.transform.position - transform.position;
        //verifica a distancia do player no eixo x y e z
        //"mathf.abs" serve para transformar o valor em absoluto para essa distancia valer tanto na direita como na esquerda
        //se a distancia do player for menor que 8 no eixo x e 5 no eixo y então:
        if(chamarSendoAtacado == false && chamarPodeAtacar == true)
        {
            if (Mathf.Abs(distanciaDoPlayer.x) < distanciaDoPlayerNoEixoX && Mathf.Abs(distanciaDoPlayer.y) < distanciaDoPlayerNoEixoY )
              {
                //inimigo se move em direcao ao player
                  rigid.velocity = new Vector2(velocidade * (distanciaDoPlayer.x / Mathf.Abs(distanciaDoPlayer.x)),rigid.velocity.y);
              }
        }

        //Pega a velocidade do Animator
        anim.SetFloat("velocidade", Mathf.Abs(rigid.velocity.x));
       
        //Se a velocidade do inimigo for maior que zero entao:
        if(rigid.velocity.x > 0 && sprite.flipX == false)
        {
         //Flip sprite
         Flip();
        }
         //Se a velocidade do inimigo for menor que zero entao:
         else if(rigid.velocity.x < 0 && sprite.flipX == true)
        {
         //Flip sprite
         Flip();
        }
        
    }
    void Flip()
    {
      //Flipar o inimigo
      sprite.flipX = !sprite.flipX;
      //Flipar Espada
      chaveInglesa.localPosition = new Vector2(-chaveInglesa.localPosition.x, chaveInglesa.localPosition.y);
    }
    
}
