using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KizauControleDeDano : MonoBehaviour
{
    public GameObject kizau;
    public Slider vida;
    public AudioClip somSofrendoDano;
    private AudioSource AS;
    public Slider energia;
    public Text energiaTexto;
    public Text vidaTexto;
    public bool intervaloDeDano;
    public string derrota;
     
    void Start()
    {
     intervaloDeDano = false;
     AS = GetComponent<AudioSource>();
     StartCoroutine(recarregar());
    }
     void Update()
     {
         
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
        if (vida.value <= 0)
        {
            kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("Morte");
            //Game Restart
            //Invoke("Restart", 3f);
           
        }
        else
        {
         AS.clip = somSofrendoDano;
         AS.Play();
         kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
         vida.value -= danoDoInimigo;
         StartCoroutine(piscarKizau());
         StartCoroutine(kizauImune());
        }
        
    }
    public void danoESP (int danoEspinhos)
    {
        if (vida.value <= 0)
        {
            kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("Morte");
            //Game Restart
            //Invoke("Restart", 3f);
           
        }
        else
        {
         AS.clip = somSofrendoDano;
         AS.Play();
         kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
         vida.value -= danoEspinhos;
         StartCoroutine(piscarKizau());
         StartCoroutine(kizauImune());
        }
        
    }
     public void destruirKizau()
    {
        Destroy(gameObject);
    }
    IEnumerator piscarKizau()
    {
        // Piscar kizau ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
             if (vida.value <= 0)
            {
            kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("Morte");
           
            }
            kizau.GetComponent<KizauAtributosDeMovimento>().sprite.enabled = false;
            kizau.GetComponent<KizauAtributosDeAtaque>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            kizau.GetComponent<KizauAtributosDeMovimento>().sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
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
