using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kizau_Soul : MonoBehaviour
{
    int enemyDamage = 8;
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    private bool dead = false;
    private bool immune = true;

    [Header("Atributos")]
    public Slider sliderLife;
    public int life = 1220;
    public int kizauDamage = 20;
    public float speed = 8f;
    public float jumpForce = 350f;

    [Header("Variáveis de Ataque")]
    public float radiusAttack;
    public Transform katana;
    public LayerMask Enemy;
    public bool isEnemy = false;
    public LayerMask whatIsEnemy;

    //[Header("Variáveis do Chão")]
    public Transform foot;
    public LayerMask whatIsFloor;
    public bool isFloor = false;
    public float radiusFoot;
    bool isJumping = false;

    [Header("Bola de Fogo")]
    public GameObject Match;
    public GameObject Ball;
    public bool rightSide = true;
    public Transform matchPosition;
    public bool Reloaded;
    public bool ShootFireBall;

    [Header("Crater")]
    public GameObject craterMatch;
    public GameObject Crater;
    public bool craterRightSide = true;
    public Transform craterMatchPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {

        //Movement();

        // Detector de chão
        //isFloor = Physics2D.Linecast(transform.position, foot.position, whatIsFloor);
        isEnemy = Physics2D.Linecast(transform.position, katana.position, whatIsEnemy);

        //if (Input.GetKeyDown(KeyCode.UpArrow) && isFloor == true)
        //{
            //isJumping = true;
        //}

        // Controle do Ataque
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //anim.SetTrigger("Attack");
            //nextAttack = Time.time + attackSpeed;
            AttackDetector();

        }

        //Bola de fogo
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Reloaded == true)
            {
                FireBallMovement();
                StartCoroutine(WaitFireBall());
            }
        }

        //Cratera
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isFloor == true)
            {
                CraterGenerete();
            }
        }

    }

    //void Movement()
    //{
        // Controle de Animação no Eixo X e Y
        //anim.SetFloat("X", Mathf.Abs(rigid.velocity.x));
        //anim.SetFloat("Y", Mathf.Abs(rigid.velocity.y));
    //}

    void FixedUpdate()
    {
        //Movimento
        float move = Input.GetAxis("Horizontal");
        if (immune == true)
        {
            rigid.velocity = new Vector2(move * speed, rigid.velocity.y);
        }
        //Detecta se "move" é negativo ou positivo
        if ((move > 0 && sprite.flipX == false) || (move < 0 && sprite.flipX == true))
        {
            Flip();
        }

        if (isJumping)
        {
            rigid.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip()
    {
        //Crater
        craterRightSide = !craterRightSide;
        craterMatchPosition.localPosition = new Vector2(-craterMatchPosition.localPosition.x, craterMatchPosition.localPosition.y);
        //FireBall
        rightSide = !rightSide;
        matchPosition.localPosition = new Vector2(-matchPosition.localPosition.x, matchPosition.localPosition.y);
        //Flipar Sprite
        sprite.flipX = !sprite.flipX;
        //Flipar Katana
        katana.localPosition = new Vector2(-katana.localPosition.x, katana.localPosition.y);
    }

    void OnDrawGizmosSelected()
    {
        //Raio do pé
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(foot.position, radiusFoot);
        //Raio da Katana
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(katana.position, radiusAttack);
    }

    public void AttackDetector()
    {
        //Colisor
        Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(katana.position, radiusAttack, Enemy);

        //Kizau Aplica Dano
        foreach (Collider2D enemy in enemyCollider)
        {
            if (enemy.tag == "Enemy" && enemy != null)
            {
                enemy.GetComponent<Enemy_Soul>().SufferingDamage(kizauDamage);
            }
        }

        // Quantos inimigos estou atacando de uma vez  
        for (int i = 0; i < enemyCollider.Length; i++)
        {
            // Menssagem de dano
            Debug.Log(enemyCollider[i].name);
            enemyCollider[i].SendMessage("EnemyHit", "20");
        }

    }

    public void SufferingDamage(int enemyDamage)
    {
        if (immune)
        {
            immune = false;
            //Dano
            life -= enemyDamage;
            if (life <= 0)
            {
                anim.SetTrigger("Dead");
                //Game Restart
                Invoke("Restart", 3f);
                DestroyKizau();
            }
            else
            {
                StartCoroutine(DamageCoroutine());
            }
        }
    }

    IEnumerator DamageCoroutine()
    {
        // Piscar Kizau ao sofrer dano
        for (float i = 0; i < 0.6f; i += 0.2f)
        {
            anim.SetTrigger("SufferingDamage");
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        immune = true;

    }

    public void DestroyKizau()
    {
        Destroy(gameObject);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FireBallMovement()
    {
        GameObject tmpBall = (GameObject)(Instantiate(Ball, Match.transform.position, Quaternion.identity));

        if (rightSide)
        {
            //tmpBall.GetComponent<KizauBolaDeFogo>().direcaoDaBolaDeFogo(Vector2.left);
        }
        else
        {
            //Direciona a bola de fogo conforme a direção que o personagem aponta
            //Importa o componente de direção do script da bola de fogo
            //tmpBall.GetComponent<KizauBolaDeFogo>().direcaoDaBolaDeFogo(Vector2.right);
            //tmpBall.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public IEnumerator WaitFireBall()
    {
        Reloaded = false;
        yield return new WaitForSeconds(3);
        Reloaded = true;
    }

   

    void CraterGenerete()
    {
        GameObject tmpCrater = (GameObject)(Instantiate(Crater, craterMatch.transform.position, Quaternion.identity));
    }
}