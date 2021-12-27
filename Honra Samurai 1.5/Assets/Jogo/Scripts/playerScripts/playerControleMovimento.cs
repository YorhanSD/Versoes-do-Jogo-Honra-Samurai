using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(AudioSource))]
public class playerControleMovimento : MonoBehaviour//NUNCA DEIXAR OS NOMES DOS SCRIPTS ERRADOS ISSO BUGA A ENGINE
{
   public GameObject bolaDeFogo, cratera;
   public Animator anim;
   public Rigidbody2D rigid;
   public SpriteRenderer sprite, sprBF;
   public FixedJoystick Joystick;
   public AudioClip somPulo;
   private AudioSource AudioS;
   public float forçaDoPulo = 1300f, velocidade = 15f;
   private float horizontal, raioDoPe = 2f;
   public Transform pe, katana, pontoDisparo, pontoCriar;
   private bool estaPulando, ladoDireito = true; 
   public bool chao;
   public LayerMask issoEChao;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        AudioS = GetComponent<AudioSource>();
        ladoDireito = transform.localScale.x > 0;
    }

    void Update()
    {
        //Detector de chão
        chao = Physics2D.Linecast(transform.position, pe.position, issoEChao);
        //Pulo do kizau
        //Ao clicar na tacla (seta para cima) e se o chão é verdadeiro então
        //"estaPulando" é verdadeiro
        if (Input.GetKeyDown(KeyCode.UpArrow) && chao == true)
        {
            estaPulando = true;
            AudioS.clip = somPulo;
            AudioS.Play();
        }
    }
    
    public void FixedUpdate()
    {
        movimentacao();
        //se esta pulando então:
        if (estaPulando)
        {
            rigid.AddForce(new Vector2(0f, forçaDoPulo));
            estaPulando = false;
        }
    }

    public void botaoPula()
    {
        if (chao == true)
        {
            estaPulando = true;
            AudioS.clip = somPulo;
            AudioS.Play();
        }
    }

    public void movimentacao()
    {
        //Controle de Animação no Eixo X e Y
        anim.SetFloat("X", Mathf.Abs(rigid.velocity.x));
        anim.SetFloat("Y", Mathf.Abs(rigid.velocity.y));

        velocidade = GetComponent<playerControleAtaque>().chamarVelocidade;
        
        //Movimento do Teclado
        float movimento = Input.GetAxis("Horizontal");

        //Movimento do Joystick
        //movimento = Joystick.Horizontal;
        
        rigid.velocity = new Vector2(movimento * velocidade, rigid.velocity.y);
        //Detecta se "move" é negativo ou positivo para flipar o kizau
        //se o movimento for maior que 0 não flipa se for flipa
        if ((movimento > 0 && sprite.flipX == false) || (movimento < 0 && sprite.flipX == true))
        {
            Flip();
            AudioS.Play();
        }

    }


    public void Flip()
    {
        //flipar Bola de fogo
        sprBF.flipX = !sprBF.flipX;
        ladoDireito = !ladoDireito;
        //flipar ponto de disparo
        pontoDisparo.localPosition = new Vector2(-pontoDisparo.localPosition.x,pontoDisparo.localPosition.y);
        
        //Flipar ponto de criacao
        pontoCriar.localPosition = new Vector2(-pontoCriar.localPosition.x,pontoCriar.localPosition.y);

        //Flipar Sprite
        sprite.flipX = !sprite.flipX;

        //Flipar Katana
        katana.localPosition = new Vector2(-katana.localPosition.x, katana.localPosition.y);
    }
    public void movimentoBF()
    {
        //cria uma bola de fogo temporaria no ponto de disparo
        GameObject bfTemp = (GameObject)(Instantiate(bolaDeFogo, pontoDisparo.transform.position, Quaternion.identity));

        if (ladoDireito!)
        {
            bfTemp.GetComponent<playerBFControle>().inicializar(Vector2.right);
        }
        else
        {
            //Direciona a bola de fogo conforme a direção que o personagem aponta
            //Importa o void inicializar com o componente de direção do script da bola de fogo
            bfTemp.GetComponent<playerBFControle>().inicializar(Vector2.left);
        }
    }
    public void diracaoBF(float horizontal)
    {
        if(horizontal > 0 && !ladoDireito || horizontal < 0 && ladoDireito)
        {
          ladoDireito = !ladoDireito;
          transform.localScale = new Vector3(-transform.localScale.x,-transform.localScale.y,-transform.localScale.z);
        }
    }
    public void gerarCratera()
    {
        GameObject crateraTemporaria = (GameObject)(Instantiate(cratera, pontoCriar.transform.position, Quaternion.identity));

        if (ladoDireito)
        {
          crateraTemporaria.GetComponent<playerCrateraControle>().Inicializar(Vector2.right);
        }
        else
        {
          crateraTemporaria.GetComponent<playerCrateraControle>().Inicializar(Vector2.left);
        }

    }
    void OnDrawGizmosSelected()
    {
        //Raio do pé
        Gizmos.color = Color.yellow;
        //desenha o raio
        Gizmos.DrawWireSphere(pe.position, raioDoPe);
        
    }

}
