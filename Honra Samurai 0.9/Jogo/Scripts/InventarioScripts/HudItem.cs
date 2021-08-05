using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudItem : MonoBehaviour
{
   public Itens item;
   public RawImage icone;
   public Text descricao;
   public Text nome;
   public GameObject nomeCapUI;
   public GameObject descricaoCapUI;
   public GameObject nomeManopUI;
   public GameObject descricaoManopUI;
    void Start()
    {
        icone.texture = item.Icone;
        descricao.text = item.Descricao;
        nome.text = item.Nome;

    }

    public void botaoCap()
    {
        nomeCapUI.SetActive(true);
        descricaoCapUI.SetActive(true);

        nomeManopUI.SetActive(false);
        descricaoManopUI.SetActive(false);
    }
    public void botaoManop()
    {
        nomeCapUI.SetActive(false);
        descricaoCapUI.SetActive(false);
        
        nomeManopUI.SetActive(true);
        descricaoManopUI.SetActive(true);
    }
   
}
