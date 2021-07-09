using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizauBolaDeFogo : MonoBehaviour
{
    public float velocidadeDaBolaDeFogo;
    public float tempoDeDestruicao;
    private Rigidbody2D rigid;
    private Vector2 direcao;
    private bool ladoDireito = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        

        tempoDeDestruicao = 5.0f;
        Destroy (gameObject, tempoDeDestruicao);
    }

    public void FixedUpdate()
    {
        rigid.velocity = direcao * velocidadeDaBolaDeFogo;
    }

    public void Inicializar(Vector2 _direcao)
    { 
       direcao = _direcao;
    }

    void OnTriggerEnter2D(Collider2D _inimigo)
    {
     if(_inimigo.gameObject.tag == "inimigo")
     {
        Destroy(gameObject);
     }


    }
    
}
