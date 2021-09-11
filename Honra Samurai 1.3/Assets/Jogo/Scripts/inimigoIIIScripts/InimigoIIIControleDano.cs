using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoIIIControleDano : MonoBehaviour
{
    public Slider vida;
    public Animator anim;
    public GameObject inimigoIII;
    public AudioClip somSofrendoDano;
    private AudioSource AudioS;
    public bool sendoAtacado;

    void Start()
    { 
        anim = GetComponent<Animator>();
        AudioS = GetComponent<AudioSource>();
    }

    public void atualizarBarraDeVida()
    {
        AudioS.clip = somSofrendoDano;
        AudioS.Play();
    }

    public void danoKizau(int danoDoKizau) //Void responsavel por receber o dano do kizau
    {
        vida.value -= danoDoKizau; //Dano do kizau subtrai a vida do inimigo nivel 3
        atualizarBarraDeVida();
        StartCoroutine(mudaCor());
        StartCoroutine(inimigoImune());
 
    }
    public void danoBF(int danoBolaDeFogo) //Void responsavel por receber o dano da bola de fogo
    {  
        vida.value -= danoBolaDeFogo; //Dano da bola de fogo subtrai a vida do inimigo nivel 3
        atualizarBarraDeVida(); //Chama a função "atualiza barra de vida
        StartCoroutine(mudaCor()); //inicia a coroutine "mudaCor"
        StartCoroutine(inimigoImune());
        Debug.Log("Bola de fogo aplicando dano");   
    }
    public void OnTriggerEnter2D (Collider2D cratera) 
    {
        if(cratera.gameObject.tag == "cratera")
        {   
         cratera.GetComponent<playerCrateraControle>().danoCratIII(inimigoIII);
         Debug.Log("Chamar Dano");           
        }
    }
    public void danoContinuoIII(int danoCratera) //Void responsavel por receber o dano da cratera
    {   
        vida.value -= danoCratera; //Dano da cratera subtrai a vida do inimigo nivel 3
        atualizarBarraDeVida(); //Chama a função "atualiza barra de vida
        StartCoroutine(mudaCor());
        Debug.Log("Cratera aplicando dano");   
    }

    public void destruirInimigo()
    {
        Destroy(gameObject); //destroi o inimigo 3
    }
    public IEnumerator mudaCor()
    {
        if (vida.value <= 0)
        {
            anim.SetTrigger("Morte");//Chama a funcao "trigger" no Animator do inimigo 3 responsavel pela animacao da morte
        }

        anim.SetTrigger("SofrendoDanoIII");//Chama a funcao "trigger" no Animator do inimigo 3 responsavel pela animacao de sofrimento de dano
        
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
            inimigoIII.GetComponent<InimigoIIIControleMovimento>().sprite.color = Color.red; //Pega o componente "sprite.color" do script do "inimigoIIIMovimento" e deixa o inimigo 3 vermelho
            yield return new WaitForSeconds(0.3f);
            inimigoIII.GetComponent<InimigoIIIControleMovimento>().sprite.color = Color.white; //Pega o componente "sprite.color" do script do "inimigoIIIMovimento" e deixa o inimigo 3 branco
        }
    }
    IEnumerator inimigoImune()
    {
        sendoAtacado = true; //Esta sendo atacado
        yield return new WaitForSeconds(2f);
        sendoAtacado = false; //Nao esta sendo atacado
    }
}
