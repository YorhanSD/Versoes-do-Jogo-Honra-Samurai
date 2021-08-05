using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMMControleDeAtaque : MonoBehaviour
{
    public int danoDaLamina = 15;
    public float velocidadeDeAtaque = 1.5f;
    public Slider chamarVida;
    //public AudioClip somLamina;
    //private AudioSource AS;
    public bool podeAtacar = true;
    public bool atacando;
    public GameObject circuloMecanico;
    private Animator anim;
    public Transform lamina;
    public float raioDasLaminas;
    public LayerMask player;

    void Start()
    {
        anim = GetComponent<Animator>();
        //AS = GetComponent<AudioSource>();
    }

    void Update()
    {
      DetectorDePlayer();
      chamarVida = GetComponent<CMMControleDeDano>().cm_Vida;

    }

    public void DetectorDePlayer()
    {
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (lamina.position, raioDasLaminas, player);
      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && podeAtacar == true && chamarVida.value >= 0)
        {
          kizau.GetComponent<KizauControleDeDano>().danoCMM(danoDaLamina);
          StartCoroutine(ProximoAtaque());
        }
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true)
      {
       //Raio das Laminas
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(lamina.position, raioDasLaminas);
      }
    }
    
    IEnumerator ProximoAtaque()
    {
      //anim.SetTrigger("ataqueGiratorio");
      //AS.clip = somLamina;
      //AS.Play();
      podeAtacar = false;
      yield return new WaitForSeconds(velocidadeDeAtaque);
      podeAtacar = true;
    }
    
}
