using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigoControleAtaque: MonoBehaviour
{
    public int danoDoInimigo = 5;
    public float velocidadeDeAtaque = 2.5f;
    public Slider chamarVida;
    public AudioClip somEspada;
    private AudioSource AS;
    public bool podeAtacar = true;
    public GameObject inimigo;
    private Animator anim;
    public Transform espada;
    public float raioDaEspada;
    public LayerMask player;

    void Start()
    {
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
      DetectorDePlayer();
      chamarVida = GetComponent<inimigoControleDano>().vida;

    }

    public void DetectorDePlayer()
    {
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (espada.position, raioDaEspada, player);
      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && podeAtacar == true && chamarVida.value > 0)
        {
          kizau.GetComponent<playerControleDano>().kizauSofrendoDano(danoDoInimigo);
          StartCoroutine(ProximoAtaque());
        }
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true)
      {
       //Raio da Espada
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(espada.position, raioDaEspada);
      }
    }
    
    IEnumerator ProximoAtaque()
    {
      anim.SetTrigger("Ataque");
      AS.clip = somEspada;
      AS.Play();
      podeAtacar = false;
      yield return new WaitForSeconds(velocidadeDeAtaque);
      podeAtacar = true;
    }
    

}
