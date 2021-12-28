using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class playerBFControle : MonoBehaviour
{
    public int danoBolaDeFogo = 15;
    public float velocidadeBF = 25f;
    private Rigidbody2D rigid;
    public Vector2 direcao;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy (gameObject, 2);
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
            inimigo.GetComponent<InimigoIIIControleDano>().danoBF(danoBolaDeFogo);
        }
        if (inimigo.gameObject.tag == "Inimigo")
        {
            inimigo.GetComponent<inimigoControleDano>().inim_levaDanoBolaDeFogo(danoBolaDeFogo);
        }
         if (inimigo.gameObject.tag == "CirculoMecanico")
        {
            inimigo.GetComponent<cmControleDano>().cm_LevaDanoBolaDeFogo(danoBolaDeFogo);
        }
        
    }
    
}
