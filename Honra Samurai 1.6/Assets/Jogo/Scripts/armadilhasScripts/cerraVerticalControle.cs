using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerraVerticalControle : MonoBehaviour
{
    private bool moveBaixo = true;
    public int danoCerra = 100;
    public float velocidade = 7f;
    public Transform pontoA;
    public Transform pontoB;
    void Update()
    {
        if(transform.position.y > pontoA.position.y)
        moveBaixo = true;
         if(transform.position.y < pontoB.position.y)
        moveBaixo = false;
        if(moveBaixo)
        transform.position = new Vector2(transform.position.x,transform.position.y - velocidade * Time.deltaTime);
        else
        transform.position = new Vector2(transform.position.x,transform.position.y + velocidade * Time.deltaTime);
    }
     void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<playerControleDano>().danoCER(danoCerra);
        }
    }
}
