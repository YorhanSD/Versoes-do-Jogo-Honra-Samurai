using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KizauControleDeDano : MonoBehaviour
{
    public GameObject kizau;
    public Slider vida;
    public bool intervaloDeDano;
        
    void Start()
    {
        intervaloDeDano = false;
    }

    public void kizauSofrendoDano(int danoDoInimigo)
    {
        //if(intervaloDeDano == false)
        //{
         vida.value -= danoDoInimigo;
         StartCoroutine(piscarKizau());
         //intervaloDeDano = true;
        //}
        //else
        //{
         StartCoroutine(kizauImune());
        //}
       
        if (vida.value <= 0)
        {
            kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("Dead");
            //Game Restart
            //Invoke("Restart", 3f);
            destruirKizau();
        }
    }
     public void destruirKizau()
    {
        Destroy(gameObject);
    }
    IEnumerator piscarKizau()
    {
        // Piscar kizau ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.2f)
        {
            //kizau.GetComponent<KizauAtributosDeMovimento>().anim.SetTrigger("sofrendoDano");
            kizau.GetComponent<KizauAtributosDeMovimento>().sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            kizau.GetComponent<KizauAtributosDeMovimento>().sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
     IEnumerator kizauImune()
    {
       yield return new WaitForSeconds(3f);
       intervaloDeDano = false; 
    }
}
