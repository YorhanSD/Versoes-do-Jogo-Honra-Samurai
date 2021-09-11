using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent (typeof(AudioSource))]
public class playerControleDano : MonoBehaviour
{
    public GameObject player;
    public Slider vida, energia;
    public Animator animCaixaDano;
    public Text caixaDano;
    public int moeda;
    public AudioClip somSofrendoDano;
    private AudioSource AS;
    public bool intervaloDeDano;
    public string nomeTelaDerrota;
     
    void Start()
    {
     intervaloDeDano = false;
     AS = GetComponent<AudioSource>();
     animCaixaDano = GetComponent<Animator>();
     StartCoroutine(recarregar());
    }
     IEnumerator recarregar()
     {
         while (energia.value <= 100)//Sempre que a energia for menor que 100 então:
         {
            yield return new WaitForSeconds(2.5f);
            energia.value += 10;//Valor da energia soma mais 10
         }
     }
     IEnumerator atualizaDano()
     {
         animCaixaDano.SetTrigger("sobeDano");//Chama o "Trigger" da animação da caixa de dano
         yield return new WaitForSeconds(1f);
         caixaDano.text = "";
     }
    public void kizauSofrendoDano(int danoDoInimigo)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("sofrendoDano");
        GameObject.FindObjectOfType<playerControleAtaque>().defKizau -= danoDoInimigo;
        caixaDano.text = "-" + danoDoInimigo;
        StartCoroutine(atualizaDano());
        if(GameObject.FindObjectOfType<playerControleAtaque>().defKizau <= 0)
        {
        GameObject.FindObjectOfType<playerControleAtaque>().defKizau = 0;//Pega o componente "defKizau" e deixa o valor dele zerado para que nao fique negativo
        vida.value -= danoDoInimigo;
        }
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }
     public void SofrendoDanoInimigoIII(int danoDoInimigoIII)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoDoInimigoIII;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }
    public void danoESP (int danoEspinhos)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoEspinhos;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune());      
    }
      public void danoCER (int danoCerra)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoCerra;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune());      
    }
     public void danoCMM(int danoDaLamina)
    {
        AS.clip = somSofrendoDano;
        AS.Play();
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("sofrendoDano");
        vida.value -= danoDaLamina;
        StartCoroutine(piscarKizau());
        StartCoroutine(kizauImune()); 
    }

    public void curaPlayer(int cura)
    {
        vida.value += cura;
    }

     public void destruirKizau()
    {
        Destroy(gameObject);
    }
    IEnumerator piscarKizau()
    {
        if (vida.value <= 0)
        {
        //chama a animacao de morte
        player.GetComponent<playerControleMovimento>().anim.SetTrigger("Morte");
        }
        
        //sprite fica vermelho ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.3f)
        {
            player.GetComponent<playerControleAtaque>().sprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<playerControleAtaque>().sprite.color = Color.white;
        }
    }
     IEnumerator kizauImune()
    {
       yield return new WaitForSeconds(2f);
       intervaloDeDano = false; 
    }
      public void telaDerrota()
    {
        SceneManager.LoadScene(nomeTelaDerrota);
    }
    
}
