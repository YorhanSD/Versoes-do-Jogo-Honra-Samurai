using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class playerBFControle : MonoBehaviour
{
    public int danoBolaDeFogo = 10;
    public float velocidadeBF = 20f;
    public float tempoDeDestruicao;
    private Rigidbody2D rigid;
    public Vector2 direcao;

    void Start()
    {
        tempoDeDestruicao = 3f;
        rigid = GetComponent<Rigidbody2D>();
        Destroy (gameObject, tempoDeDestruicao);
    }

    public void FixedUpdate()
    {
      rigid.velocity = direcao * velocidadeBF;
    }

    public void inicializar(Vector2 _direcao)
    { 
       //diz qual é a direcao da bola de fogo quando for instanciada
       direcao = _direcao;
       Debug.Log("Bola de fogo instanciada");
    }

    void OnTriggerEnter2D(Collider2D inimigo)
    {
        if (inimigo.gameObject.tag == "InimigoIII")
        {
            //inimigo.GetComponent<inimigoIIIControleDeDano>().danoBF(danoBolaDeFogo);
            inimigo.GetComponent<inimigoControleDano>().inim_levaDanoBolaDeFogo(danoBolaDeFogo);
        }
    }
    
}
