using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cmVidaTexto : MonoBehaviour
{
    public float vidaCompleta = 150;
    public Text vidaTexto;
    public Slider barraDeVida;
   
    void Update()
    {
      vidaTexto.text = vidaCompleta + " / " + barraDeVida.value;
    }
}
