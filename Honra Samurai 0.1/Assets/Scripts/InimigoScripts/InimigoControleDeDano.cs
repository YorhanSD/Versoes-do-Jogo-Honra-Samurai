using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControleDeDano : MonoBehaviour
{
    public GameObject inimigo;
    public bool sendoAtacado;
    public int Vida = 100;
    public bool intervaloDeDano;
        
    void Start()
    {
        intervaloDeDano = false;
    }

    public void inimigoSofrendoDano(int danoDoKizau)
    {
        if(intervaloDeDano == false)
        {
         Vida -= danoDoKizau;
         sendoAtacado = true;
         StartCoroutine(piscarKizau());
         intervaloDeDano = true;
        }
        else
        {
         StartCoroutine(inimigoImune());
        }
       
        if (Vida <= 0)
        {
            //inimigo.GetComponent<InimigoAtributosDeMovimento>().anim.SetTrigger("Dead");
            //Game Restart
            //Invoke("Restart", 3f);
            destruirInimigo();
        }
    }
     public void destruirInimigo()
    {
        Destroy(gameObject);
    }
    IEnumerator piscarKizau()
    {
        // Piscar kizau ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.2f)
        {
            //inimigo.GetComponent<InimigoAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            inimigo.GetComponent<InimigoAtributosDeMovimento>().sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
     IEnumerator inimigoImune()
    {
       yield return new WaitForSeconds(1.5f);
       intervaloDeDano = false; 
       sendoAtacado = false;
    }
}
