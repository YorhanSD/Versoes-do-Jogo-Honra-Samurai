using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipamentos : MonoBehaviour
{
    private EquiparDescartar EquiparDescartar;
    private playerControleAtaque playerControleAtaque;
    public bool capAtlant,manop,escud,peitCour,relans,capShog;
    public GameObject[] slotEquip;
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
            slotEquip[0].SetActive(false);
            EquiparDescartar.limite[0] += 1;
            playerControleAtaque.desequipouCapAtlant = true;
            Debug.Log("voce desequipou o capacete atlantis com sucesso");
        }
        if(manop == true)
        {
            slotEquip[1].SetActive(false);
            EquiparDescartar.limite[1] += 1;
            playerControleAtaque.desequipouManop = true;
            Debug.Log("voce desequipou a manopla dragonica com sucesso");
            
        }
        if(escud == true)
        {
            slotEquip[2].SetActive(false);
            EquiparDescartar.limite[2] += 1;
            playerControleAtaque.desequipouEscud = true;
            Debug.Log("voce desequipou o escudo lendario com sucesso");
        }
        if (peitCour == true)
        {
            slotEquip[3].SetActive(false);
            EquiparDescartar.limite[3] += 1;
            playerControleAtaque.desequipouPeitCour = true;
            Debug.Log("voce desequipou o peitoral de couro com sucesso");
        }
        if (relans == true)
        {
            slotEquip[4].SetActive(false);
            EquiparDescartar.limite[4] += 1;
            playerControleAtaque.desequipouRelans = true;
            Debug.Log("voce desequipou a relanspada com sucesso");
        }
        if (capShog == true)
        {
            slotEquip[5].SetActive(false);
            EquiparDescartar.limite[5] += 1;
            playerControleAtaque.desequipouCapShog = true;
            Debug.Log("voce desequipou o capacete do shogum com sucesso");
        }

    }
}
