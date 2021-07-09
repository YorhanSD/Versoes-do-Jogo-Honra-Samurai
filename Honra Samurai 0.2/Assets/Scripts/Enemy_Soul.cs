using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Soul : MonoBehaviour
{
   
    public Slider sliderLife;
    public int enemyDamage = 8;
    private float speed = 3f;
    public int maxLife = 1190;
    int currentLife;
    int kizauDamage = 20;
    public float attackSpeed = 3.8f;



    public float radiusAttack;
    public Transform sword;
    public LayerMask Player;
    public LayerMask whatIsPlayer;
    public bool isPlayer = false;
    private float nextAttack;




    public GameObject damageText;
    private Rigidbody2D rigid;
    private Transform playerPosition;
    private Vector3 playerDistance;
    Animator anim;
    SpriteRenderer sprite;
    private bool dead = false;
    private bool attackEnemy = false;
    private bool run = true;
   


     
    void Start()
    {
        //Vida Atual sempre que o Jogo reiniciar vai ser igual a vida máxima
        currentLife = maxLife;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

      AttackDetector();

      isPlayer = Physics2D.Linecast(transform.position, sword.position, whatIsPlayer);
      
    }

  void FixedUpdate()
  {
  
    if(dead == false)
    {
      //Distancia do Player
      playerDistance = playerPosition.transform.position - transform.position;

           if(run == true && attackEnemy == false)
          {

              if (Mathf.Abs(playerDistance.x) <8 && Mathf.Abs(playerDistance.y) < 5 )
              {
                  
                  rigid.velocity = new Vector2(speed * (playerDistance.x / Mathf.Abs(playerDistance.x)),rigid.velocity.y);
               
              }

          }       
      //Pega a velocidade do Animator
      anim.SetFloat("SpeedEnemy", Mathf.Abs(rigid.velocity.x));
       
      //Flip sprite
      if(rigid.velocity.x > 0 && !sprite.flipX)
      {
        Flip();
      }
      else if(rigid.velocity.x < 0 && sprite.flipX)
      {
        Flip();
      }
  }
}

    void Flip()
    {
      sprite.flipX = !sprite.flipX;
       //Flipar Espada
      sword.localPosition = new Vector2(-sword.localPosition.x, sword.localPosition.y);
    }
   
     public void EnemyHit(string value)
    {//Quando Texto de Dano não for nulo

     if(damageText != null)
     {
      var Damage = Instantiate (damageText, transform.position, Quaternion.identity);
      Damage.SendMessage("SetText", value);
     }

    }

     public void SufferingDamage(int kizauDamage)
    {
        //Tirar vida
        currentLife -= kizauDamage;
        anim.SetTrigger("EnemySufferingDamage");
        attackEnemy = false;
  
        if(currentLife <= 0)
        {
          //Morte
          dead = true;
          rigid.velocity = Vector2.zero;
          anim.SetTrigger("DeadEnemy");
          GetComponent<BoxCollider2D>().enabled = false;
          DestroyEnemy();
          
        }
        else
        {
        StartCoroutine(DamageCoroutine());
        }

    }
    IEnumerator DamageCoroutine()
    {
        //Loop de cor ao sofrer dano

        for (float i = 0; i < 0.6f ; i+= 0.2f)
        {
            anim.SetTrigger("EnemySufferingDamage");
            sprite.enabled = false;
            yield return new WaitForSeconds(0.2f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
       
    }

    public void DestroyEnemy()
    {
      //Destruir Inimigo
        Destroy(gameObject);
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{

      //Kizau_Soul Kizau = collision.gameObject.GetComponent<Kizau_Soul>();

      //if(Kizau.tag == "Player")
      //{
       // Anim.SetTrigger("AttackEnemy");

        //Aplicar dano no Kizau
        //Kizau.SufferingDamage(EnemyDamage);
        //Aplicar força do ataque
       // Kizau.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2 * (PlayerDistance.x / Mathf.Abs(PlayerDistance.x)),ForceMode2D.Impulse);
      //}
    //}
    public void AttackDetector()
    {
      //Colisor
      Collider2D[] kizauCollider = Physics2D.OverlapCircleAll (sword.position, radiusAttack, Player);

      //Inimigo Aplica Dano
      foreach(Collider2D kizau in kizauCollider)
      {
        if(kizau.tag == "Player" && kizau !=null)
        {
          anim.SetTrigger("AttackEnemy");
          kizau.GetComponent<Kizau_Soul>().SufferingDamage(enemyDamage);
          sliderLife.value -= enemyDamage;
          kizau.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1 * (playerDistance.x / Mathf.Abs(playerDistance.x)),ForceMode2D.Impulse);

        }
      }
    }

    void OnDrawGizmosSelected()
    {
      // Raio da Espada
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(sword.position, radiusAttack);

    }


    





    private void EnemyAttack()
    //Atacar
    {
      run = false;
      attackEnemy = true;
    }
    

    private void EnemyReset()
    //Resetar Ataque
    {
      run = true;
      attackEnemy = false;
    }
    
    //private void OnTriggerEnter2D(Collider2D other)
 //{
  //if(other.tag == "Player" && AttackEnemy == true)
  //{
    //Tirar Vida da Barra de Vida
    //sliderLife.value -= EnemyDamage;
  //}
 //}


}