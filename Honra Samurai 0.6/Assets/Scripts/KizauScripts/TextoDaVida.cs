using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDaVida : MonoBehaviour
{
    public float vidaCompleta = 180;
    public Text vidaTexto;
    public Slider barraDeVida;
    
    void Start()
    {
      barraDeVida = GetComponent<KizauControleDeDano>().vida;
    }

    void Update()
    {
      vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;
    }
}
