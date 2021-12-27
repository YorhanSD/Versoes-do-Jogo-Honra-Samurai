using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class playerControleAtaque : MonoBehaviour//NUNCA DEIXAR OS NOMES DOS SCRIPTS ERRADOS ISSO BUGA A ENGINE
{
    public Animator anim,animCaixaDano;
    public SpriteRenderer sprite;
    private AudioSource AudioS;
    public AudioClip somAtaque;
    public int danoKizau = 20, defKizau = 10;
    public Text ata,def,caixaDano;
    private bool podeAtacar = true, podeUsarNovamente = true, atacando = false, podeUsarDeNovo = true; 
    public bool capAtlantsEqui,manopEqui,escudEqui,peitCourEqui,relansEqui,capShogEqui;
    public bool desequipouCapAtlant = false, desequipouManop = false, desequipouEscud = false, desequipouPeitCour = false, desequipouRelans = false, desequipouCapShog = false;
    public bool sendoAtacado = false;
    public float chamarVelocidade, raioAtaque;
    public Slider chamarEnergia, chamarVida; 
    public GameObject kizau;
    public Transform katana;
    public LayerMask inimigo;

      void Start()
    {
        anim = GetComponent<Animator>();
        animCaixaDano = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        AudioS = GetComponent<AudioSource>();
        chamarVelocidade = 20;
    }

    void Update()
    {
        if (danoKizau < 20)
        {
            danoKizau = 20;
        }

        if(defKizau < 0)
        {
            defKizau = 0;
        }

        equipamentos();

        ata.text =  "ATA: " + danoKizau;
        def.text =  "DEF: " + defKizau;

        chamarEnergia = GetComponent<playerControleDano>().energia;//Pega o componente "energia" no script "playerControleDano"

        if (Input.GetKeyDown(KeyCode.Q) && podeAtacar == true && atacando == false)//Quando a tecla "Q" for pressionada e o player poder atacar e nao estiver atacando:
          { 
            detectaInimigo();
            StartCoroutine(ProximoAtaque());
          } 
         
          if (Input.GetKeyDown(KeyCode.W))
         {
             if(chamarEnergia.value >= 20)
             {
              kizau.GetComponent<playerControleMovimento>().movimentoBF();
              custoBF();
              recargaBF();
              Debug.Log("Bola de Fogo");
             }
         } 

          if (Input.GetKeyDown(KeyCode.E) && GetComponent<playerControleMovimento>().chao == true)
          {
            if(chamarEnergia.value >= 40)
            {
             kizau.GetComponent<playerControleMovimento>().gerarCratera();
             custoDaCratera();
            Debug.Log("Cratera");
            }
          }
            
            if (Input.GetKeyDown(KeyCode.R))
         {    
            if(chamarEnergia.value >= 60)
           {
             detectaInimigo();
             StartCoroutine(ultimate());
             Debug.Log("Ultimate do Kizau");
           }
         } 
    }
    public void botaoAtaque()
    {
        if (podeAtacar == true && atacando == false)
        {
            KizauAtaque();
            StartCoroutine(ProximoAtaque());
        }
     
    }
    public void botaoBolaDeFogo()
    {
      if(chamarEnergia.value >= 20 && podeUsarNovamente == true)
        {
        kizau.GetComponent<playerControleMovimento>().movimentoBF();
        custoBF();
        StartCoroutine(recargaBF());
        Debug.Log("Bola de Fogo");
        }
    }
    public void botaoCratera()
    {
      if(chamarEnergia.value >= 40)
      {
        //verificar se esta chamando do jeito certo as Coroutines
        kizau.GetComponent<playerControleMovimento>().gerarCratera();
        custoDaCratera();
        StartCoroutine(recargaCratera());//Inicia a coroutine "recargaCratera"
        Debug.Log("Cratera");
      }

    }
    public void botaoUltamate()
    {
      if(chamarEnergia.value >= 60)
      {
        detectaInimigo();
        StartCoroutine(ultimate());
        Debug.Log("Ultimate do Kizau");
      }
    }

    void OnDrawGizmosSelected()
    {
      if(podeAtacar == true && atacando == false)
      {
      //Raio da Katana
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(katana.position, raioAtaque);
      }
    }

    public void detectaInimigo()
    {
        //a katana ira detectar se e um inimigo
        Collider2D[] colisorInimigo = Physics2D.OverlapCircleAll(katana.position, raioAtaque, inimigo);//A katana ao se colidir com o colisor do inimigo detectara que e um inimigo

        foreach (Collider2D inimigo in colisorInimigo)
        {
            caixaDano.text = "-" + danoKizau;
            StartCoroutine(atualizaDanoKizau());

            if (inimigo.tag == "Inimigo")
            {
              inimigo.GetComponent<inimigoControleDano>().inimigoSofrendoDano(danoKizau);
            }
            if(inimigo.tag == "InimigoIII")
            {
              inimigo.GetComponent<InimigoIIIControleDano>().danoKizau(danoKizau);
            }
             if(inimigo.tag == "CirculoMecanico")
            {
              inimigo.GetComponent<cmControleDano>().cm_LevaDanoKizau(danoKizau);
            }
        }
    }
    public IEnumerator atualizaDanoKizau()
    {
        animCaixaDano.SetTrigger("sobeDano");//Chama o "Trigger" da animação da caixa de dano
        yield return new WaitForSeconds(1);
        caixaDano.text = "";
    }

    public void KizauAtaque()
    {
        if (podeAtacar == true && atacando == false && sendoAtacado == false)
        {
            anim.SetTrigger("Ataque");
            AudioS.clip = somAtaque;
            AudioS.Play();
            detectaInimigo();
            Debug.Log("kizau ataca");

        }
    }
    IEnumerator ProximoAtaque()
    {
      podeAtacar = false;
      atacando = true;
      yield return new WaitForSeconds(1);
      podeAtacar = true;
      atacando = false;
      sendoAtacado = false;
    }
     public IEnumerator recargaBF()
    {
        podeUsarNovamente = false;
        yield return new WaitForSeconds(2);
        podeUsarNovamente = true;
    }
    public IEnumerator recargaCratera()
    {
        podeUsarDeNovo = false;
        yield return new WaitForSeconds(3);
        podeUsarDeNovo = true;
    }

    public void custoBF()
     {
         chamarEnergia.value -= 20;
     }
      public void custoDaCratera()
     {
         chamarEnergia.value -= 40;
     }

    public IEnumerator ultimate()
    {
        chamarEnergia.value -= 60;
        sprite.color = Color.red;
        danoKizau += 30;
        chamarVelocidade += 10;
        yield return new WaitForSeconds(6);
        sprite.color = Color.white;
        danoKizau -= 30;
        chamarVelocidade -=10;
    }

    public void equipamentos()
    {
      if(capAtlantsEqui == true)
      {
        defKizau +=30;
        danoKizau +=10;
        capAtlantsEqui = false;
      }
      else
      {
        if(desequipouCapAtlant == true)
        {
        defKizau -=30;
        danoKizau -=10;
        desequipouCapAtlant = false;
        }
      }
      if(manopEqui == true)
      {
        danoKizau +=7;
        defKizau +=7;
        manopEqui = false;
      }
      else
      {
        if(desequipouManop == true)
        {
          danoKizau -=7;
          defKizau -=7;
          desequipouManop = false;
        }
      }
      if(escudEqui == true)
      {
        defKizau +=1;
        escudEqui = false;
      }
      else
      {
        if(desequipouEscud == true)
        {
          defKizau -= 1;
          desequipouEscud = false;
        }
      }
      if(peitCourEqui == true)
      {
        defKizau +=12;
        peitCourEqui = false;
      }
      else
      {
        if (desequipouPeitCour == true)
        {
          defKizau -= 12;
          desequipouPeitCour = false;
        }
      }
      if(relansEqui == true)
      {
        danoKizau +=80;
        relansEqui = false;
      }
        else
        {
            if(desequipouRelans == true)
            {
                danoKizau -= 80;
                desequipouRelans = false;
            }
        }
      if(capShogEqui == true)
      {
        danoKizau +=35;
        defKizau +=200;
        capShogEqui = false;
      }
      else
      {
           if(desequipouCapShog == true)
           {
               danoKizau -= 35;
               defKizau -= 200;
               desequipouCapShog = false;
           }

      }

    }
   

}
