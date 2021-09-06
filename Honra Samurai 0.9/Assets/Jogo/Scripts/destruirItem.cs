using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirItem : MonoBehaviour
{
    public int quantCaps, quantManop, quantRelan, quantEscud = 0;
    public void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.name == "capaceteAtlantis")
        {
            quantCaps +=1;
            GameObject.FindObjectOfType<pegaItens>().atualizaCaps(quantCaps);
            Debug.Log("pegou capacete atlantis");
        }
        if(player.gameObject.name == "manoplaDragonica")
        {
            quantManop +=1;
            GameObject.FindObjectOfType<pegaItens>().atualizaManop(quantManop);
            Debug.Log("pegou manopla dragonica");
        }
         if(player.gameObject.name == "relanspada")
        {
            quantRelan +=1;
            GameObject.FindObjectOfType<pegaItens>().atualizaRelan(quantRelan);
            Debug.Log("pegou manopla dragonica");
        }
         if(player.gameObject.name == "oLendarioEscudoDeCarvalho")
        {
            quantEscud +=1;
            GameObject.FindObjectOfType<pegaItens>().atualizaEscud(quantEscud);
            Debug.Log("pegou o lendario escudo de carvalho");
        }

    }
}
