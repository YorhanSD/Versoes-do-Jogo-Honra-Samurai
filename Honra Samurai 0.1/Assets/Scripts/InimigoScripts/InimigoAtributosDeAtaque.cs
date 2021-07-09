using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtributosDeAtaque : MonoBehaviour
{
    public int danoDoInimigo = 5;
    public bool intervaloDeAtaque;
    public bool atacando;
    public GameObject inimigo;
    private Animator anim;
    public Transform espada;
    public float raioDaEspada;
    public LayerMask player;

    // Start is called before the first frame update
    void Start()
    {
        intervaloDeAtaque = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      atacarPlayerDetector();
    }
    public void atacarPlayerDetector()
    {
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (espada.position, raioDaEspada, player);
      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && intervaloDeAtaque == false)
        {
          kizau.GetComponent<KizauControleDeDano>().kizauSofrendoDano(danoDoInimigo);
          intervaloDeAtaque = true;
          StartCoroutine(possoAtacarNovamenteCoroutine());
        }
      }
    }
    public void animacaoDoAtaque()
    {
      anim.SetTrigger("inimigoPodeAtacar");
    }

    void OnDrawGizmosSelected()
    {
      //Raio da Espada
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(espada.position, raioDaEspada);
    }
    IEnumerator possoAtacarNovamenteCoroutine()
    {
      atacando = true;
      animacaoDoAtaque();
      intervaloDeAtaque = true;
      yield return new WaitForSeconds(1.5f);
      intervaloDeAtaque = false;
      atacando = false;
    }

}
