using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizauAtributosDeAtaque : MonoBehaviour
{
    public Animator anim;
    public int danoDoKizau = 20;
    public GameObject kizau;
    public float raioDoAtaque;
    public Transform katana;
    public LayerMask inimigo;
    private GameObject bolaDeFogo;
    private bool recargaDaBolaDeFogo;

       void Start()
    {
         anim = GetComponent<Animator>();
    }

    void Update()
    { 
         if (Input.GetKeyDown(KeyCode.Q))
         {    
           atacarInimigoDetector();
         } 
         
          if (Input.GetKeyDown(KeyCode.W) && kizau != null)
         {
             kizau.GetComponent<KizauAtributosDeMovimento>().movimentoDaBolaDeFogo();
             Debug.Log("Bola de fogo");
         } 
    }
    void OnDrawGizmosSelected()
    {
        //Raio da Katana
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(katana.position, raioDoAtaque);
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
        // Quantos inimigos estou atacando de uma vez  
        for (int i = 0; i < enemyCollider.Length; i++)
        {
            // Menssagem de dano
            Debug.Log(enemyCollider[i].name);
            //enemyCollider[i].SendMessage("kizau aplica 20 de dano ao inimigo");
        }
    }
     public IEnumerator tempoDeRecargaDaBolaDeFogo()
    {
        recargaDaBolaDeFogo = false;
        yield return new WaitForSeconds(3);
        recargaDaBolaDeFogo = true;
    }
   

}
