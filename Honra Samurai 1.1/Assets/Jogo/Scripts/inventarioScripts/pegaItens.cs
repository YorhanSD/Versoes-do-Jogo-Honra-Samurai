using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pegaItens : MonoBehaviour
{
    public Item[] itemNome; //vetor de itens para guardar quais são os itens
    public int[] Contador; //vetor de contadores para guardas as quantidades dos itens
    public void OnTriggerEnter2D(Collider2D player)
    {
        //Checar sempre se o GameObject esta chamando a função correta
        if(player.gameObject.name == itemNome[0].Nome)//se o player encostar no objeto que o nome do item 0 então:
        {
            Contador[0] += 1; //contador conta 1
            GameObject.FindObjectOfType<armazenaItens>().atualizaCaps(Contador[0]); //chama o componente "atualizaCaps" no script "armazenaItens" e atualiza o contador 0 que é o capacete atlantis
            Debug.Log("pegou capacete atlantis"); 
        }
        if(player.gameObject.name == itemNome[1].Nome)
        {
            Contador[1] += 1;
            GameObject.FindObjectOfType<armazenaItens>().atualizaManop(Contador[1]); //chama o componente "atualizaManop" no script "armazenaItens" e atualiza o contador 1 que é a manopla dragonica
            Debug.Log("pegou manopla dragonica");
        }
         if(player.gameObject.name == itemNome[2].Nome)
        {
            Contador[2] += 1;
            GameObject.FindObjectOfType<armazenaItens>().atualizaEscud(Contador[2]);
            Debug.Log("pegou o lendario escudo de carvalho");
        }
         if(player.gameObject.name == itemNome[3].Nome)
        {
            Contador[3] += 1;
            GameObject.FindObjectOfType<armazenaItens>().atualizaCour(Contador[3]);
            Debug.Log("pegou peitoral de couro");
        }

        if(player.gameObject.name == itemNome[4].Nome)
        {
            Contador[4] += 1;
            GameObject.FindObjectOfType<armazenaItens>().atualizaRelans(Contador[4]);
            Debug.Log("pegou relanspada");
        }
          if(player.gameObject.name == itemNome[5].Nome)
        {
            Contador[5] += 1;
            GameObject.FindObjectOfType<armazenaItens>().atualizaCapshog(Contador[5]);
            Debug.Log("pegou capacete do shogum");
        }

    }
}
