using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KizauBolaDeFogo : MonoBehaviour
{
    public int danoBolaDeFogo = 10;
    public float velocidadeDaBolaDeFogo = 20f;
    public float tempoDeDestruicao;
    private Rigidbody2D rigid;
    private Vector2 direcao;

    void Start()
    {
        tempoDeDestruicao = 3f;
        rigid = GetComponent<Rigidbody2D>();
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

    void OnTriggerEnter2D(Collider2D inimigo)
    {
        if (inimigo.gameObject.tag == "InimigoIII")
        {
            inimigo.GetComponent<InimigoIIIControleDeDano>().danoBF(danoBolaDeFogo);
            inimigo.GetComponent<InimigoControleDeDano>().inim_levaDanoBolaDeFogo(danoBolaDeFogo);
        }
    }
    
    
}
