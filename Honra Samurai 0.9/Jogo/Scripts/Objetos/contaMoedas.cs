using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contaMoedas : MonoBehaviour
{
    public int moedas = 0;
    public Text totalMoedas;

     public void contaMoeda(int adicionaMoeda)
    {
        moedas += adicionaMoeda;
        totalMoedas.text =  ": " + moedas;
    }


    void Update()
    {
       
    }
}
