using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pegaItens : MonoBehaviour
{
    public GameObject slot, slotII,slotIII,slotIV,slotV;
    public Text quantidade, quantidadeII, quantidadeIII,quantidadeIV,quantidadeV;
    public void atualizaCaps(int quantCaps)
    {
      //ativa o slot 1 pertencente ao capacete atlantis no canvas do inventario
      slot.SetActive(true);
      //adiciona a quantidade do item coletada pelo jogador
      quantidade.text = "x" + quantCaps;
      Debug.Log("Capacete Atlantis Armazenado");
    }
    public void atualizaManop(int quantManop)
    {
      //ativa o slot 2 pertencente a manopla dragonica no canvas do inventario
      slotII.SetActive(true);
      quantidadeII.text = "x" + quantManop;
      Debug.Log("Manopla Dragonica Armazenada");
    }
    public void atualizaRelan(int quantRelan)
    {
      //ativa o slot 3 pertencente a relanspada no canvas do inventario
      slotIII.SetActive(true);
      quantidadeIII.text = "x" + quantRelan;
      Debug.Log("Relanspada Armazenada");
    }
    public void atualizaEscud(int quantEscud)
    {
      //ativa o slot 4 pertencente ao escudo lendario no canvas do inventario
      slotIV.SetActive(true);
      quantidadeIV.text = "x" + quantEscud;
      Debug.Log("O lendario escudo de carvalho Armazenada");
    }
   
}
