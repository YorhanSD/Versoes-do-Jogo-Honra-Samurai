﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoControleDeDano : MonoBehaviour
{
    public Slider vida;
    public Animator anim;
    public GameObject inimigo;
    public AudioClip somSofrendoDano;
    private AudioSource AS;
    public bool sendoAtacado;
    
    //public Transform barraDeVida;
    //public GameObject localDaBarraDeVida;
    //public Vector3 escalaDaBarraDeVida;
    //public float percentualDeVida;


    void Start()
    { 
        
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        //escalaDaBarraDeVida = barraDeVida.localScale;
        //percentualDeVida = escalaDaBarraDeVida.x / vida;
       
    }

    public void atualizarBarraDeVida()
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        //escalaDaBarraDeVida.x = percentualDeVida * vida;
        //barraDeVida.localScale = escalaDaBarraDeVida;
    }

    public void inimigoSofrendoDano(int _danoDoKizau)
    {
        vida.value -= _danoDoKizau;
        atualizarBarraDeVida();
        StartCoroutine(piscarInimigo());
        StartCoroutine(inimigoImune());
 
    }
    public void inim_levaDanoBolaDeFogo (int _danoBolaDeFogo)
    {  
        vida.value -= _danoBolaDeFogo;
        atualizarBarraDeVida();
        StartCoroutine(piscarInimigo());
        StartCoroutine(inimigoImune());
        Debug.Log("Bola de fogo aplicando dano");   
    }
    public void OnTriggerEnter2D (Collider2D _cratera)
    {
        if(_cratera.gameObject.tag == "cratera")
        {   
         _cratera.GetComponent<Cratera>().danoCrat(inimigo);
         Debug.Log("Chamar Dano");           
        }
    }
    public void danoContinuo(int danoCratera)
    {   
        vida.value -= danoCratera;
        atualizarBarraDeVida();
        StartCoroutine(piscarInimigo());
        Debug.Log("Cratera aplicando dano");   
    }

    public void destruirInimigo()
    {
        Destroy(gameObject);
    }
    public IEnumerator piscarInimigo()
    {
        if (vida.value <= 0)
        {
            anim.SetTrigger("Morte");
        }

        anim.SetTrigger("sofrendoDano");
        
        // Piscar inimigo ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.color = Color.white;
        }
    }
    IEnumerator inimigoImune()
    {
        sendoAtacado = true;
        yield return new WaitForSeconds(2f);
        sendoAtacado = false;
    }

}
