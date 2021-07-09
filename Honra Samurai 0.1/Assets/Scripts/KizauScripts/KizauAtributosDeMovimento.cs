﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizauAtributosDeMovimento : MonoBehaviour
{
   public Animator anim;
   public Rigidbody2D rigid;
   public SpriteRenderer sprite;
   public float velocidadeDoKizau = 10;
   public float forçaDoPulo = 100f;
   public Transform pe;
   public float raioDoPe;
   public Transform katana;
   bool ladoDireito = false;
   bool estaPulando; 
   public LayerMask issoEChao;
   public bool chao;
   public Transform pontoDeDisparo;
   public GameObject bolaDeFogo;
   
  


    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movimentacao();
        // Detector de chão
        chao = Physics2D.Linecast(transform.position, pe.position, issoEChao);
        //pulo do kizau
        //ao clicar na tacla (seta para cima) e se o chão é verdadeiro
        if (Input.GetKeyDown(KeyCode.UpArrow) && chao == true)
        {
            estaPulando = true;
        }
    }
    void FixedUpdate()
    {
        float movimento = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(movimento * velocidadeDoKizau, rigid.velocity.y);
        
         //Detecta se "move" é negativo ou positivo para flipar o kizau
         //se o movimento for maior que 0 não flipa se for flipa
        if ((movimento > 0 && sprite.flipX == false) || (movimento < 0 && sprite.flipX == true))
        {
            Flip();
        }
        //se esta pulando então:
        if (estaPulando)
        {
            rigid.AddForce(new Vector2(0f, forçaDoPulo));
            estaPulando = false;
        }
    }
    void movimentacao()
    {
        // Controle de Animação no Eixo X e Y
        anim.SetFloat("X", Mathf.Abs(rigid.velocity.x));
        anim.SetFloat("Y", Mathf.Abs(rigid.velocity.y));
    }

    public void Flip()
    {
        ladoDireito =! ladoDireito;
        pontoDeDisparo.localPosition = new Vector2(-pontoDeDisparo.localPosition.x,pontoDeDisparo.localPosition.y);
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
            bolaDeFogoTemporaria.GetComponent<KizauBolaDeFogo>().Inicializar(Vector2.right);
        }
        else
        {
            //Direciona a bola de fogo conforme a direção que o personagem aponta
            //Importa o componente de direção do script da bola de fogo
            bolaDeFogoTemporaria.GetComponent<KizauBolaDeFogo>().Inicializar(Vector2.left);
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