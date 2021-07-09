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
    public bool podeAtacar = true; 
    public bool atacando = false;
    public float chamarVelocidadeDoKizau;
    public Slider chamarEnergia; 
    public GameObject kizau;
    public float raioDoAtaque;
    public Transform katana;
    public LayerMask inimigo;
    private GameObject bolaDeFogo;
    private bool recargaDaBolaDeFogo;

       void Start()
    {
         anim = GetComponent<Animator>();
         sprite = GetComponent<SpriteRenderer>();
         AS = GetComponent<AudioSource>();
         chamarVelocidadeDoKizau = 10;
    }

    void Update()
    { 
        chamarEnergia = GetComponent<KizauControleDeDano>().energia;

          if (Input.GetKeyDown(KeyCode.Q) && podeAtacar == true)
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
        Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(katana.position, raioDoAtaque, inimigo);

        foreach (Collider2D enemy in enemyCollider)
        {
            if (enemy.tag == "Inimigo")
            {
              enemy.GetComponent<InimigoControleDeDano>().inimigoSofrendoDano(danoDoKizau);
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
        recargaDaBolaDeFogo = false;
        yield return new WaitForSeconds(2f);
        recargaDaBolaDeFogo = true;
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
        danoDoKizau += 300;
        chamarVelocidadeDoKizau += 10;
        yield return new WaitForSeconds(5);
        sprite.color = Color.white;
        danoDoKizau -= 300;
        chamarVelocidadeDoKizau -=10;
    }
   

}
