using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipamentos : MonoBehaviour
{
    private EquiparDescartar EquiparDescartar;
    private playerControleAtaque playerControleAtaque;
    public bool capAtlant,manop,escud,peitCour,relans,capShog;
    public GameObject[] slotEquipamento;
    public GameObject telaEquipamentos;

    public void Awake()
    {
        EquiparDescartar = GetComponent<EquiparDescartar>();
        playerControleAtaque = GetComponent<playerControleAtaque>();
    }
    public void botaoVoltar()
    {
        telaEquipamentos.SetActive(false);
    }
    public void botaoCapAtlant()
    {
        capAtlant = true;
    }
    public void botaoManop()
    {
        manop = true;
    }
    public void botaoEscud()
    {
        escud = true;
    }
    public void botaoPeitCour()
    {
        peitCour = true;
    }
    public void botaoRelans()
    {
        relans = true;
    }
    public void botaoCapShog()
    {
        capShog = true;
    }
    public void desequipar()
    {
        if(capAtlant == true)
        {
            slotEquipamento[0].SetActive(false);
            EquiparDescartar.limiteCapAtlantis += 1;
            playerControleAtaque.desequipouCapAtlant = true;
            Debug.Log("voce desequipou o capacete atlantis");
        }
        if(manop == true)
        {
            slotEquipamento[1].SetActive(false);
            EquiparDescartar.limiteManop += 1;
            playerControleAtaque.desequipouManop = true;
            Debug.Log("voce desequipou a manopla dragonica");
            
        }


    }
}
