using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigoVidaTexto : MonoBehaviour
{
    public float vidaCompleta = 80;
    public Text vidaTexto;
    public Slider barraDeVida;
   
    void Update()
    {
      vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;
    }
    
}

