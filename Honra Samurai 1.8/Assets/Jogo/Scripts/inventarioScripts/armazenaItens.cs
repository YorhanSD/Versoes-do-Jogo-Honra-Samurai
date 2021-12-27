using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armazenaItens : MonoBehaviour
{
    public Text[] quantidade;
    public GameObject[] slot;
    public void atualizaCaps(int Contador = 0)
    {
        quantidade[0].text = "X" + Contador;
        slot[0].SetActive(true);
    }
    public void atualizaManop(int Contador = 1)
    {
        quantidade[1].text = "X" + Contador;
        slot[1].SetActive(true);
    }
    public void atualizaEscud(int Contador = 2)
    {
        quantidade[2].text = "X" + Contador;
        slot[2].SetActive(true);
    }
    public void atualizaCour(int Contador = 3)
    {
        quantidade[3].text = "X" + Contador;
        slot[3].SetActive(true);
    }
    public void atualizaRelans(int Contador = 4)
    {
        quantidade[4].text = "X" + Contador;
        slot[4].SetActive(true);
    }
    public void atualizaCapshog(int Contador = 5)
    {
        quantidade[5].text = "X" + Contador;
        slot[5].SetActive(true);
    }
}