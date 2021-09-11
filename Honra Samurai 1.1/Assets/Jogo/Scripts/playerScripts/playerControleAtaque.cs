using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class playerControleAtaque : MonoBehaviour//NUNCA DEIXAR OS NOMES DOS SCRIPTS ERRADOS ISSO BUGA A ENGINE
{
    public Animator anim;
    public SpriteRenderer sprite;
    private AudioSource AudioS;
    public AudioClip somAtaque;
    public int danoKizau = 20, defKizau = 10;
    public Text ata,def;
    private bool podeAtacar = true, podeUsarNovamente = true, atacando = false, podeUsarDeNovo = true; 
    public bool capAtlantsEqui,manopEqui,escudEqui,peitCourEqui,relansEqui,capShogEqui;
    public float chamarVelocidade, raioAtaque, velocidadeAtaque = 1.5f;
    public Slider chamarEnergia, chamarVida; 
    public GameObject kizau;
    public Transform katana;
    public LayerMask inimigo;

       void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        AudioS = GetComponent<AudioSource>();
        chamarVelocidade = 25;
    }

    void Update()
    { 
        equipamentos();//Void que movimenta o player

        ata.text =  "ATA: " + danoKizau;
        def.text =  "DEF: " + defKizau;

        chamarEnergia = GetComponent<playerControleDano>().energia;//Pega o componente "energia" no script "playerControleDano"

        if (Input.GetKeyDown(KeyCode.Q) && podeAtacar == true && atacando == false)//Quando a tecla "Q" for pressionada e o player poder atacar e n�o estiver atacando:
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
      if(podeAtacar == true && atacando == false)
      {
      detectaInimigo();
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
      {//verificar se esta chamando do jeito certo as Coroutines
        kizau.GetComponent<playerControleMovimento>().gerarCratera();
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
      if(podeAtacar == true)
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
     IEnumerator ProximoAtaque()
    { 
      anim.SetTrigger("Ataque");
      Debug.Log("kizau ataca");
      AudioS.clip = somAtaque;
      AudioS.Play();
      atacando = true;
      podeAtacar = false;
      yield return new WaitForSeconds(velocidadeAtaque);
      podeAtacar = true;
      atacando = false;
    }
     public IEnumerator recargaBF()
    {
        podeUsarNovamente = false;
        yield return new WaitForSeconds(1.5f);
        podeUsarNovamente = true;
    }
    public IEnumerator recargaCratera()
    {
        podeUsarDeNovo = false;
        yield return new WaitForSeconds(2.5f);
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
        chamarVelocidade += 15;
        yield return new WaitForSeconds(10);
        sprite.color = Color.white;
        danoKizau -= 30;
        chamarVelocidade -=15;
    }

    public void equipamentos()
    {
      if(capAtlantsEqui == true)
      {
        defKizau +=20;
        danoKizau +=5;
        capAtlantsEqui = false;
      }
      if(manopEqui == true)
      {
        danoKizau +=5;
        defKizau +=5;
        manopEqui = false;
      }
      if(escudEqui == true)
      {
        defKizau +=1;
        escudEqui = false;
      }
      if(peitCourEqui == true)
      {
        defKizau +=8;
        peitCourEqui = false;
      }
      if(relansEqui == true)
      {
        danoKizau +=60;
        relansEqui = false;
      }
      if(capShogEqui == true)
      {
        danoKizau +=20;
        defKizau +=100;
        capShogEqui = false;
      }

    }
   

}
