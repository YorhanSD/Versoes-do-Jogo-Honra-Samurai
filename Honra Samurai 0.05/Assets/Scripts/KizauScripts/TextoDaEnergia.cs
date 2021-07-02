using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDaEnergia : MonoBehaviour
{
    public float energiaCompleta = 100;
    public Text energiaTexto;
    public Slider barraDeEnergia;
    
    void Start()
    {
      barraDeEnergia = GetComponent<KizauControleDeDano>().energia;
    }

    void Update()
    {
      energiaTexto.text = energiaCompleta + " / " + barraDeEnergia.value;
    }
}
