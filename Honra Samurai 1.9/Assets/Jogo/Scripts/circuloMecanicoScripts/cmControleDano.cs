using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cmControleDano : MonoBehaviour
{
    public Slider cm_Vida;
    public Animator anim;
    public GameObject circuloMecanico;

    public AudioClip cmSomSofrendoDano;
    private AudioSource AS;
    public bool sendoAtacado;
    public bool intervaloDeDano;

    void Start()
    { 
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        intervaloDeDano = false;
    }

    public void atualizarBarraDeVida()
    {
        AS.clip = cmSomSofrendoDano;
        AS.Play();
    }

    public void cm_LevaDanoKizau (int _danoDoKizau)
    {
        cm_Vida.value -= _danoDoKizau;
        atualizarBarraDeVida();
        StartCoroutine(piscarCM());
        StartCoroutine(cm_Imune());
        Debug.Log("Circulo mecanico leva dano do kizau");
 
    }
     public void cm_LevaDanoBolaDeFogo (int _danoBolaDeFogo)
    {  
        cm_Vida.value -= _danoBolaDeFogo;
        atualizarBarraDeVida();
        StartCoroutine(piscarCM());
        StartCoroutine(cm_Imune());
        Debug.Log("Bola de fogo aplicando dano");   
    }
    public void OnTriggerEnter2D (Collider2D _cratera)
    {
        if(_cratera.gameObject.tag == "cratera")
        {   
         _cratera.GetComponent<playerCrateraControle>().danoCratCirculoM(circuloMecanico);
         Debug.Log("Chamar Dano");           
        }
    }
    public void cm_LevaDanoCratera (int _danoCratera)
    {   
        cm_Vida.value -= _danoCratera;
        atualizarBarraDeVida();
        StartCoroutine(piscarCM());
        Debug.Log("Cratera aplicando dano");   
    }

    public void destruirCM()
    {
        Destroy(gameObject);
    }
    public IEnumerator piscarCM()
    {
      
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
             if (cm_Vida.value <= 0)
             {
               destruirCM();
             }
            circuloMecanico.GetComponent<cmControleMovimento>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            circuloMecanico.GetComponent<cmControleMovimento>().sprite.color = Color.white;
        }
    }
    IEnumerator cm_Imune()
    {
        sendoAtacado = true;
        intervaloDeDano = true;
        yield return new WaitForSeconds(2f);
        sendoAtacado = false;
        intervaloDeDano = false;
    }
}
