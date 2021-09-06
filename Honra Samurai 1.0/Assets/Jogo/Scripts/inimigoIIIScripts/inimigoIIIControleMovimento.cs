using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]//componente "Rigidbody2D" e requisitado
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Slider))]
public class inimigoIIIMovimento : MonoBehaviour
{
    public float velocidade = 25f;
    public Slider chamarVida;
    public int distanciaDoPlayerNoEixoX = 10, distanciaDoPlayerNoEixoY = 10;
    public GameObject inimigo;
    public Transform chaveInglesa;
    public bool chamarPodeAtacar, chamarSendoAtacado;
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
        chamarSendoAtacado = GetComponent<inimigoIIIControleDeDano>().sendoAtacado; //pega o componente "atacando" no script "InimigoAtributosDeAtaque"
        chamarPodeAtacar = GetComponent<inimigoIIIAtaque>().podeAtacar; //pega o componente "podeAtacar" no script "InimigoIIIAtaque"
        chamarVida = GetComponent<inimigoIIIControleDeDano>().vida; //pega o componente "vida" no script "inimigoIIIControleDeDano"

        distanciaDoPlayer = posicaoDoPlayer.transform.position - transform.position;//verifica a distancia do player no eixo x y e z

        if(chamarSendoAtacado == false && chamarPodeAtacar == true) // Quando ele não estiver sendo atacado e nem atacando ele pode andar
        {
          //"mathf.abs" serve para transformar o valor em absoluto para essa distancia valer tanto na direita como na esquerda
            if (Mathf.Abs(distanciaDoPlayer.x) < distanciaDoPlayerNoEixoX && Mathf.Abs(distanciaDoPlayer.y) < distanciaDoPlayerNoEixoY)//Detecta a distancia do player
              {//Se a distancia do player for menor que 50 no eixo X e 50 no eixo Y então:
                  rigid.velocity = new Vector2(velocidade * (distanciaDoPlayer.x / Mathf.Abs(distanciaDoPlayer.x)),rigid.velocity.y);//inimigo se move em direcao ao player
              }
        }

        anim.SetFloat("velocidade", Mathf.Abs(rigid.velocity.x));//Pega a velocidade do Animator
  
        if(rigid.velocity.x > 0 && sprite.flipX == false)//Se a velocidade do inimigo for maior que zero entao:
        {
         
         Flip();//Chama o void flip
        }
        else if(rigid.velocity.x < 0 && sprite.flipX == true)//Se a velocidade do inimigo for menor que zero entao:
        {
        
         Flip();//Chama o void flip
        }
        
    }
    void Flip()
    {
      sprite.flipX = !sprite.flipX;//Flipa o sprite do inimigo 3
      chaveInglesa.localPosition = new Vector2(-chaveInglesa.localPosition.x, chaveInglesa.localPosition.y);//Flipa a posicao da chave inglesa
    }
    
}
