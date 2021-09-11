using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiparDescartar : MonoBehaviour
{
    private itemUI itemUI;
    public int limiteCapAtlantis = 1;
    public int limiteManop = 1;
    public int capacidade = 1;
    public GameObject equipar;
    public GameObject descartar;
    public GameObject telaEquipamentos;
    public GameObject inventario;
    public GameObject[] slotEquipamentos;

    public void Start()
    {
        itemUI = GetComponent<itemUI>();
    }
    public void botaoEquipamentos()
    {
        telaEquipamentos.SetActive(true);
        inventario.SetActive(false);
    }

    //public void AtualizaCapacidade(int adicionar)
    //{
        //capacidade += adicionar;
        //Debug.Log("voce liberou um equipamento");
    //}
    public void botaoEquipar()
    {
       if(GameObject.FindObjectOfType<itemUI>().capAtlan == true)
       {
            if(limiteCapAtlantis > 0) //so pode equipar 1 capacete atlantis
            {
                limiteCapAtlantis -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[0] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[0].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[0];
                GameObject.FindObjectOfType<playerControleAtaque>().capAtlantsEqui = true;
                Debug.Log("capacete atlantis foi equipado");
                slotEquipamentos[0].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[0] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[0].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().capAtlan = false;
                }
            }
       }
       if(GameObject.FindObjectOfType<itemUI>().manop == true)
       {
            if (limiteManop > 0)
            {
                limiteManop -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[1] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[1].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[1];
                GameObject.FindObjectOfType<playerControleAtaque>().manopEqui = true;
                Debug.Log("manopla dragonica foi equipada");
                slotEquipamentos[1].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[1] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[1].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().capAtlan = false;
                }
            }
       }
        //if (GetComponent<itemUI>().escud == true)
        //{
            if (capacidade >10) 
            {
                capacidade -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[2] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[2].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[2];
                GameObject.FindObjectOfType<playerControleAtaque>().escudEqui = true;
                Debug.Log("o lendario escudo de carvalho foi equipado");
                slotEquipamentos[2].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[2] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[2].SetActive(false);
                    GetComponent<itemUI>().escud = false;
                }
            }
        //}
       //if(GetComponent<itemUI>().peitCour == true)
       //{
            if (capacidade > 10)
            {
                capacidade -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[3] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[3].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[3];
                GameObject.FindObjectOfType<playerControleAtaque>().peitCourEqui = true;
                Debug.Log("o peitoral de couro foi equipado");
                slotEquipamentos[3].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[3] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[3].SetActive(false);
                    GetComponent<itemUI>().peitCour = false;
                }
            }
       //}
       //if(GetComponent<itemUI>().relans == true)
       //{
            if (capacidade > 10)
            {
                capacidade -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[4] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[4].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[4];
                GameObject.FindObjectOfType<playerControleAtaque>().relansEqui = true;
                Debug.Log("a relanspada foi equipada");
                slotEquipamentos[4].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[4] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[4].SetActive(false);
                    GetComponent<itemUI>().relans = false;
                }
            }
       //}
        //if(GetComponent<itemUI>().capShog == true)
       //{
            if (capacidade > 10)
            {
                capacidade -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[5] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[5].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[5];
                GameObject.FindObjectOfType<playerControleAtaque>().capShogEqui = true;
                Debug.Log("o capacete do shogum foi equipado");
                slotEquipamentos[5].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[5] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[5].SetActive(false);
                    GetComponent<itemUI>().capShog = false;
                }
            }
       //}
    }
    public void botaoDescartar()
    {
        if (GameObject.FindObjectOfType<itemUI>().capAtlan == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[0] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[0].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[0];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[0] <= 0)//destiva o slot 0
            {
               GameObject.FindObjectOfType<armazenaItens>().slot[0].SetActive(false);
               GameObject.FindObjectOfType<itemUI>().capAtlan = false;
            }
            
        }
        if (GameObject.FindObjectOfType<itemUI>().manop == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[1] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[1].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[1];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[1] <= 0)//destiva o slot 0
            {
                GameObject.FindObjectOfType<armazenaItens>().slot[1].SetActive(false);
                GameObject.FindObjectOfType<itemUI>().manop = false;
            }

        }
    }
    
}
