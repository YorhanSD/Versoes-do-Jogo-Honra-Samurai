using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KizauControleDeDano : MonoBehaviour
{
    public GameObject kizau;
    public Slider vida;
    public int moeda;
    public AudioClip somSofrendoDano;
    private AudioSource AS;
    public Slider energia;
    public bool intervaloDeDano;
    public string derrota;
     
    void Start()
    {
     intervaloDeDano = false;
     AS = GetComponent<AudioSource>();
     StartCoroutine(recarregar());
    }
     IEnumerator recarregar()
     {
         while (energia.value <= 100)
         {
            yield return new WaitForSeconds(2.5f);
            energia.value += 10;
         }
     }
    public void kizauSofrendoDano(int danoDoInimigo)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoDoInimigo;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }
     public void SofrendoDanoInimigoIII(int danoDoInimigoIII)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoDoInimigoIII;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }
    public void danoESP (int danoEspinhos)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoEspinhos;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune());      
    }
      public void danoCER (int danoCerra)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoCerra;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune());      
    }
     public void danoCMM(int danoDaLamina)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoDaLamina;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }

    public void cura(int potencialCura)
    {
        vida.value += potencialCura;
    }

     public void destruirKizau()
    {
        Destroy(gameObject);
    }
    IEnumerator piscarKizau()
    {
        if (vida.value <= 0)
        {
        kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("Morte");
        }
        
        // Piscar kizau ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
            kizau.GetComponent<KizauAtributosDeAtaque>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            kizau.GetComponent<KizauAtributosDeAtaque>().sprite.color = Color.white;
        }
    }
     IEnumerator kizauImune()
    {
       yield return new WaitForSeconds(2f);
       intervaloDeDano = false; 
    }
      public void telaDerrota()
    {
        SceneManager.LoadScene(derrota);
    }
    
}
