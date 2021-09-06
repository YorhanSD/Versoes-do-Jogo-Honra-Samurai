using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KizauAtributosDeAtaque : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    private AudioSource AS;
    public AudioClip somAtaque;
    public int danoDoKizau = 20;
    public float velocidadeDeAtaque = 1.5f;
    private bool podeAtacar = true; 
    private bool atacando = false;
    public float chamarVelocidadeDoKizau;
    public Slider chamarEnergia; 
    public Slider chamarVida; 
    public GameObject kizau;
    public float raioDoAtaque;
    public Transform katana;
    public LayerMask inimigo;
    private bool podeUsarNovamente = true;

       void Start()
    {
         anim = GetComponent<Animator>();
         sprite = GetComponent<SpriteRenderer>();
         AS = GetComponent<AudioSource>();
         chamarVelocidadeDoKizau = 25;
    }

    void Update()
    { 
        chamarEnergia = GetComponent<KizauControleDeDano>().energia;

          if (Input.GetKeyDown(KeyCode.Q) && podeAtacar == true && atacando == false)
          { 
            atacarInimigoDetector();
            StartCoroutine(ProximoAtaque());
          } 
         
          if (Input.GetKeyDown(KeyCode.W))
         {
             if(chamarEnergia.value >= 20)
             {
              kizau.GetComponent<KizauAtributosDeMovimento>().movimentoDaBolaDeFogo();
              custoDaBolaDeFogo();
              tempoDeRecargaDaBolaDeFogo();
              Debug.Log("Bola de Fogo");
             }
         } 

          if (Input.GetKeyDown(KeyCode.E) && GetComponent<KizauAtributosDeMovimento>().chao == true)
          {
            if(chamarEnergia.value >= 40)
            {
             kizau.GetComponent<KizauAtributosDeMovimento>().gerarCratera();
             custoDaCratera();
            Debug.Log("Cratera");
            }
          }
            
            if (Input.GetKeyDown(KeyCode.R))
         {    
            if(chamarEnergia.value >= 60)
           {
             atacarInimigoDetector();
             StartCoroutine(ultimateDoKizau());
             Debug.Log("Ultimate do Kizau");
           }
         } 
    }
    public void botaoAtaque()
    {
      if(podeAtacar == true && atacando == false)
      {
      atacarInimigoDetector();
      StartCoroutine(ProximoAtaque());
      }
    }
    public void botaoBolaDeFogo()
    {
      if(chamarEnergia.value >= 20 && podeUsarNovamente == true)
        {
        kizau.GetComponent<KizauAtributosDeMovimento>().movimentoDaBolaDeFogo();
        custoDaBolaDeFogo();
        StartCoroutine(tempoDeRecargaDaBolaDeFogo());
        Debug.Log("Bola de Fogo");
        }
    }
    public void botaoCratera()
    {
       if(chamarEnergia.value >= 40)
      {
        kizau.GetComponent<KizauAtributosDeMovimento>().gerarCratera();
        custoDaCratera();
        Debug.Log("Cratera");
      }

    }
    public void botaoUltamate()
    {
       if(chamarEnergia.value >= 60)
      {
        atacarInimigoDetector();
        StartCoroutine(ultimateDoKizau());
        Debug.Log("Ultimate do Kizau");
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true)
      {
      //Raio da Katana
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(katana.position, raioDoAtaque);
      }
    }

    public void atacarInimigoDetector()
    {
        //a katana ira detectar se e um inimigo
        Collider2D[] colisorInimigo = Physics2D.OverlapCircleAll(katana.position, raioDoAtaque, inimigo);

        foreach (Collider2D inimigo in colisorInimigo)
        {
            if (inimigo.tag == "Inimigo")
            {
              inimigo.GetComponent<InimigoControleDeDano>().inimigoSofrendoDano(danoDoKizau);
            }
            if(inimigo.tag == "InimigoIII")
            {
              inimigo.GetComponent<InimigoIIIControleDeDano>().danoKizau(danoDoKizau);
            }
        }
    }
     IEnumerator ProximoAtaque()
    { 
      anim.SetTrigger("Ataque");
      Debug.Log("Kizau Ataque");
      AS.clip = somAtaque;
      AS.Play();
      atacando = true;
      podeAtacar = false;
      yield return new WaitForSeconds(velocidadeDeAtaque);
      podeAtacar = true;
      atacando = false;
    }
     public IEnumerator tempoDeRecargaDaBolaDeFogo()
    {
        podeUsarNovamente = false;
        yield return new WaitForSeconds(1.5f);
        podeUsarNovamente = true;
    }
     public void custoDaBolaDeFogo()
     {
         chamarEnergia.value -= 20;
     }
      public void custoDaCratera()
     {
         chamarEnergia.value -= 40;
     }

    public IEnumerator ultimateDoKizau()
    {
        chamarEnergia.value -= 60;
        sprite.color = Color.red;
        danoDoKizau += 30;
        chamarVelocidadeDoKizau += 15;
        yield return new WaitForSeconds(10);
        sprite.color = Color.white;
        danoDoKizau -= 30;
        chamarVelocidadeDoKizau -=15;
    }
   

}
