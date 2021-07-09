using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    //Estados
    Attack,
    Run,
    Idle
}
public class EnemyNível1 : MonoBehaviour
{
    public GameObject Boleadeiras;
    public float shootSpeed = 10;

    public GameObject Player;
    public Rigidbody2D Rigid;

    //Estado recebe todos os estados
    private enemyState State;
    private Vector3 initialPosition;
    private Vector3 runTo;
    private float Stopwatch;
    void Start()
    {

        Rigid = GetComponent<Rigidbody2D>();
        //O inimigo inicia parado
        State = enemyState.Idle;
        Stopwatch = 0;
        initialPosition = transform.position;
        runTo = new Vector3(initialPosition.x + Random.Range(-5, 5),
            initialPosition.y + Random.Range(0, 0));
    }

    void Update()
    {
        switch (State)
        {
            case enemyState.Run:
                updateRun ();
                break;

            case enemyState.Idle:
                updateIdle ();
                break;

            case enemyState.Attack:
                updateAttack ();
                break;
        }

    }
    void updateRun()
    {
        //Posição em que o inimigo deve ir menos a sua posição atual
        Vector3 Direction = runTo - transform.position;
        Direction.y = 0;
        //Aponta para uma direção sem aplicar velocidade
        Direction.Normalize();
        //Velocidade
        Vector3 Speed = Direction * 7;
        //Mantem a velocidade que ele tinha em Y
        Speed.y = Rigid.velocity.y;
        Rigid.velocity = Speed;

        if(Vector2.Distance (transform.position, runTo) <= 3f)
        {
            runTo = new Vector3(initialPosition.x + Random.Range(-5, 5),
                initialPosition.y + Random.Range(0, 0));
                
        }

        Stopwatch = Stopwatch + Time.deltaTime;
        if(Stopwatch >= 6f)
        {
            State = enemyState.Idle;
            Stopwatch = 0;
        }
        

    }
    void updateIdle()
    {

    }
    void updateAttack()
    {

    }
    public void Shoot()
    {
        //GameObject Boleadeiras = Instantiate(boleadeirasPrefab, transform.position, Quaternion.identity);
        //Vector3 Direction = (player.transform.position - transform.position).normalized;
       //Boleadeiras.GetComponent<Rigidbody2D>().velocity = Direction * shootSpeed;
    }
}
