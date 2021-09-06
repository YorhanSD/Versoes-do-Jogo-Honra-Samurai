using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigoIIIAtaque : MonoBehaviour
{
    public int danoDoInimigoIII = 50;
    public float velocidadeDeAtaque = 3f;
    public Slider chamarVida;
    public AudioClip somChaveInglesa;
    private AudioSource AS;
    public bool podeAtacar = true;
    public GameObject inimigoIII;
    private Animator anim;
    public Transform chaveInglesa;
    public float raioDaChaveInglesa;
    public LayerMask player;

    void Start()
    {
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
      DetectorDePlayer();
      chamarVida = GetComponent<inimigoIIIControleDeDano>().vida;

    }

    public void DetectorDePlayer()
    {
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (chaveInglesa.position, raioDaChaveInglesa, player);
      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && podeAtacar == true && chamarVida.value > 0)
        {
          kizau.GetComponent<playerControleDano>().kizauSofrendoDano(danoDoInimigoIII);
          StartCoroutine(ProximoAtaque());
        }
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true)
      {
       //Raio da Chave Inglesa
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(chaveInglesa.position, raioDaChaveInglesa);
      }
    }
    
    IEnumerator ProximoAtaque()
    {
      anim.SetTrigger("Ataque");
      AS.clip = somChaveInglesa;
      AS.Play();
      podeAtacar = false;
      yield return new WaitForSeconds(velocidadeDeAtaque);
      podeAtacar = true;
    }
}
