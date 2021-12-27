
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoIIIControleAtaque : MonoBehaviour//NUNCA DEIXAR OS NOMES DOS SCRIPTS ERRADOS ISSO BUGA A ENGINE
{
    public int danoDoInimigoIII = 50;

    public Slider chamarVida;
    public AudioClip somChaveInglesa;
    private AudioSource AS;
    public bool podeAtacar = true, sendoAtacado = false;
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
      chamarVida = GetComponent<InimigoIIIControleDano>().vida;
    }

    public void DetectorDePlayer()
    {
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (chaveInglesa.position, raioDaChaveInglesa, player);
      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && podeAtacar == true && sendoAtacado == false && chamarVida.value > 0)
        {
          kizau.GetComponent<playerControleDano>().kizauSofrendoDano(danoDoInimigoIII);
          StartCoroutine(ProximoAtaque());
        }
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true && sendoAtacado == false)
      {
       //Raio da Chave Inglesa
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(chaveInglesa.position, raioDaChaveInglesa);
      }
    }
    
    IEnumerator ProximoAtaque()
    {
      anim.SetTrigger("Ataque");
      podeAtacar = false;
      yield return new WaitForSeconds(0.3f);
      AS.clip = somChaveInglesa;
      AS.Play();
      yield return new WaitForSeconds(4.7f);
      podeAtacar = true;
      sendoAtacado = false;
    }
}
