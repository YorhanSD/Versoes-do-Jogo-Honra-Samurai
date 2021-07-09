using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControleDeDano : MonoBehaviour
{
    public int vida = 80;
    public Animator anim;
    public GameObject inimigo;
    public AudioClip somSofrendoDano;
    private AudioSource AS;
    public bool sendoAtacado;
    public bool intervaloDeDano;
    public Transform barraDeVida;
    public GameObject localDaBarraDeVida;
    public Vector3 escalaDaBarraDeVida;
    public float percentualDeVida;


    void Start()
    { 
        
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        escalaDaBarraDeVida = barraDeVida.localScale;
        percentualDeVida = escalaDaBarraDeVida.x / vida;
        intervaloDeDano = false;
    }

    public void atualizarBarraDeVida()
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        escalaDaBarraDeVida.x = percentualDeVida * vida;
        barraDeVida.localScale = escalaDaBarraDeVida;
    }

    public void inimigoSofrendoDano(int danoDoKizau)
    {
        vida -= danoDoKizau;
        if(vida >= 0)
        {
        atualizarBarraDeVida();
        }
        StartCoroutine(piscarInimigo());
        StartCoroutine(inimigoImune());
 
    }
     public void danoBF (int danoBolaDeFogo)
    {  
        vida -= danoBolaDeFogo;
         if(vida >= 0)
        {
        atualizarBarraDeVida();
        }
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
        vida -= danoCratera;
        if(vida >= 0)
        {
        atualizarBarraDeVida();
        }
        StartCoroutine(piscarInimigo());
        Debug.Log("Cratera aplicando dano");   
    }

    public void destruirInimigo()
    {
        Destroy(gameObject);
    }
    public IEnumerator piscarInimigo()
    {
        // Piscar inimigo ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
             if (vida <= 0)
             {
               anim.SetTrigger("Morte");
             }
            anim.SetTrigger("sofrendoDano");
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.enabled = false;
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.enabled = true;
            yield return new WaitForSeconds(0.2f);
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.color = Color.white;
        }
    }
    IEnumerator inimigoImune()
    {
        sendoAtacado = true;
        intervaloDeDano = true;
        yield return new WaitForSeconds(5f);
        sendoAtacado = false;
        intervaloDeDano = false;
    }

}
