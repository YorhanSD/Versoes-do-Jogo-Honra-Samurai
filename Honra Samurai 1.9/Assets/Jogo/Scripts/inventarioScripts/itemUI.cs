using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemUI : MonoBehaviour
{
   public Item[] item;
   public RawImage[] icone;
   public Text[] descricao;
   public Text[] nome;

   public bool capAtlan = false, manop = false, escud = false, peitCour = false, relans = false, capShog = false;

    public void Start()
    {
        icone[0].texture = item[0].Icone;
        icone[1].texture = item[1].Icone;
        icone[2].texture = item[2].Icone;
        icone[3].texture = item[3].Icone;
        icone[4].texture = item[4].Icone;
        icone[5].texture = item[5].Icone;     
    }

    public void botaoCap()//Botao do slot do capacete atlantis
    {
        descricao[0].text = item[0].Descricao;
        nome[0].text= item[0].Nome;

        capAtlan = true;
        peitCour = false;
        capShog = false;
        relans = false;
        manop = false;
        escud = false;

    }
    public void botaoManop()//Botao do slot da manopla dragonica
    {
        descricao[1].text = item[1].Descricao;
        nome[1].text= item[1].Nome;

        manop = true;
        peitCour = false;
        capShog = false;
        relans = false;
        capAtlan = false;
        escud = false;
    }
    public void botaoEscud() //Botao do slot do lendario escudo de carvalho
    {
        descricao[2].text = item[2].Descricao;
        nome[2].text= item[2].Nome;

        escud = true;
        peitCour = false;
        capShog = false;
        relans = false;
        capAtlan = false;
        manop = false;
    }
    public void botaoPeitcour() //Botao do slot do peitoral de couro
    {
        descricao[3].text = item[3].Descricao;
        nome[3].text= item[3].Nome;

        peitCour = true;
        capShog = false;
        relans = false;
        escud = false;
        capAtlan = false;
        manop = false;
    }
    public void botaoRelans() //Botao do slot da relanspada
    {
        descricao[4].text = item[4].Descricao;
        nome[4].text= item[4].Nome;

        relans = true;
        capShog = false;
        peitCour = false;
        escud = false;
        capAtlan = false;
        manop = false;
    }

     public void botaoCapshog()
    {
        descricao[5].text = item[5].Descricao;
        nome[5].text= item[5].Nome;

        capShog = true;
        relans = false;
        peitCour = false;
        escud = false;
        capAtlan = false;
        manop = false;
    }
   
}
