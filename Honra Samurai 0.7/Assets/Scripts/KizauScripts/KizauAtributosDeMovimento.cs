using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizauAtributosDeMovimento : MonoBehaviour
{
   public Animator anim;
   public Rigidbody2D rigid;
   public SpriteRenderer sprite;
   public FixedJoystick Joystick;
   public AudioClip somPulo;
   public AudioClip somArmadura;
   private AudioSource AS;
   public float velocidadeDoKizau;
   public float forçaDoPulo = 100f;
   public Transform pe;
   public float raioDoPe;
   public Transform katana;
   public bool ladoDireito = true;
   private bool estaPulando; 
   public LayerMask issoEChao;
   public bool chao;
   public Transform pontoDeDisparo;
   public Transform pontoDeCriar;
   public GameObject bolaDeFogo;
   public GameObject cratera;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Detector de chão
        chao = Physics2D.Linecast(transform.position, pe.position, issoEChao);
        //pulo do kizau
        //ao clicar na tacla (seta para cima) e se o chão é verdadeiro
        if (Input.GetKeyDown(KeyCode.UpArrow) && chao == true)
        {
            estaPulando = true;
            AS.clip = somPulo;
            AS.Play();
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
            AS.clip = somPulo;
            AS.Play();
        }
    }

    public void movimentacao()
    {
        //Controle de Animação no Eixo X e Y
        anim.SetFloat("X", Mathf.Abs(rigid.velocity.x));
        anim.SetFloat("Y", Mathf.Abs(rigid.velocity.y));

        velocidadeDoKizau = GetComponent<KizauAtributosDeAtaque>().chamarVelocidadeDoKizau;
        
        //Movimento do teclado
        float movimento = Input.GetAxis("Horizontal");
        

        //Movimento do Joystick
        movimento = Joystick.Horizontal;
        
        rigid.velocity = new Vector2(movimento * velocidadeDoKizau, rigid.velocity.y);
         //Detecta se "move" é negativo ou positivo para flipar o kizau
         //se o movimento for maior que 0 não flipa se for flipa
        if ((movimento > 0 && sprite.flipX == false) || (movimento < 0 && sprite.flipX == true))
        {
            Flip();
            AS.clip = somArmadura;
            AS.Play();
        }

    }


    public void Flip()
    {
        //flipar Bola de fogo
        ladoDireito = !ladoDireito;
        pontoDeDisparo.localPosition = new Vector2(-pontoDeDisparo.localPosition.x,pontoDeDisparo.localPosition.y);
        
        //Flipar cratera
        pontoDeCriar.localPosition = new Vector2(-pontoDeCriar.localPosition.x,pontoDeCriar.localPosition.y);

        //Flipar Sprite
        sprite.flipX = !sprite.flipX;

        //Flipar Katana
        katana.localPosition = new Vector2(-katana.localPosition.x, katana.localPosition.y);
    }
    public void movimentoDaBolaDeFogo()
    {
        //cria uma bola de fogo temporaria no ponto de disparo
        GameObject bolaDeFogoTemporaria = (GameObject)(Instantiate(bolaDeFogo, pontoDeDisparo.transform.position, Quaternion.identity));

        if (ladoDireito)
        {
            bolaDeFogoTemporaria.GetComponent<KizauBolaDeFogo>().Inicializar(Vector2.left);
        }
        else
        {
            //Direciona a bola de fogo conforme a direção que o personagem aponta
            //Importa o componente de direção do script da bola de fogo
            bolaDeFogoTemporaria.GetComponent<KizauBolaDeFogo>().Inicializar(Vector2.right);
        }
    }
    public void gerarCratera()
    {
        GameObject crateraTemporaria = (GameObject)(Instantiate(cratera, pontoDeCriar.transform.position, Quaternion.identity));

         if (ladoDireito)
        {
            crateraTemporaria.GetComponent<Cratera>().Inicializar(Vector2.left);
        }
        else
        {
            crateraTemporaria.GetComponent<Cratera>().Inicializar(Vector2.right);
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
