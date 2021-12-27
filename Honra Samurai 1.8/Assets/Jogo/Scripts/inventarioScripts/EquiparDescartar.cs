using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiparDescartar : MonoBehaviour
{
    private itemUI itemUI;
    private Equipamentos Equipamentos;

    public int[] limite;
    public GameObject equipar;
    public GameObject descartar;
    public GameObject telaEquipamentos;
    public GameObject inventario;
    public void Start()
    {
        itemUI = GetComponent<itemUI>();
        Equipamentos = GetComponent<Equipamentos>();

        limite[0] = 1;
        limite[1] = 1;
        limite[2] = 1;
        limite[3] = 1;
        limite[4] = 1;
        limite[5] = 1;
    }
    public void botaoEquipamentos()
    {
        telaEquipamentos.SetActive(true);
        inventario.SetActive(false);
    }
    public void botaoEquipar()
    {
       if(GameObject.FindObjectOfType<itemUI>().capAtlan == true)
       {
            if(limite[0] > 0) //so pode equipar 1 capacete atlantis
            {
                limite[0] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[0] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[0].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[0];
                GameObject.FindObjectOfType<playerControleAtaque>().capAtlantsEqui = true;
                Debug.Log("capacete atlantis foi equipado");
                Equipamentos.slotEquip[0].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[0] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[0].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().capAtlan = false;
                }
            }
       }
       if(GameObject.FindObjectOfType<itemUI>().manop == true)
       {
            if (limite[1] > 0)
            {
                limite[1] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[1] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[1].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[1];
                GameObject.FindObjectOfType<playerControleAtaque>().manopEqui = true;
                Debug.Log("manopla dragonica foi equipada");
                Equipamentos.slotEquip[1].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[1] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[1].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().capAtlan = false;
                }
            }
       }
        if (GameObject.FindObjectOfType<itemUI>().escud == true)
        {
            if (limite[2] > 0) 
            {
                limite[2] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[2] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[2].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[2];
                GameObject.FindObjectOfType<playerControleAtaque>().escudEqui = true;
                Debug.Log("o lendario escudo de carvalho foi equipado");
                Equipamentos.slotEquip[2].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[2] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[2].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().escud = false;
                }
            }
        }
       if(GameObject.FindObjectOfType<itemUI>().peitCour == true)
       {
            if (limite[3] > 0)
            {
                limite[3] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[3] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[3].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[3];
                GameObject.FindObjectOfType<playerControleAtaque>().peitCourEqui = true;
                Debug.Log("o peitoral de couro foi equipado");
                Equipamentos.slotEquip[3].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[3] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[3].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().peitCour = false;
                }
            }
       }
        if(GameObject.FindObjectOfType<itemUI>().relans == true)
        {
        if (limite[4] > 0)
           {
                limite[4] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[4] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[4].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[4];
                GameObject.FindObjectOfType<playerControleAtaque>().relansEqui = true;
                Debug.Log("a relanspada foi equipada");
                Equipamentos.slotEquip[4].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[4] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[4].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().relans = false;
                }
           }
       }
        if(GameObject.FindObjectOfType<itemUI>().capShog == true)
       {
            if (limite[5] > 0)
            {
                limite[5] -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[5] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[5].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[5];
                GameObject.FindObjectOfType<playerControleAtaque>().capShogEqui = true;
                Debug.Log("o capacete do shogum foi equipado");
                Equipamentos.slotEquip[5].SetActive(true);
                if (GameObject.FindObjectOfType<pegaItens>().Contador[5] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[5].SetActive(false);
                    GameObject.FindObjectOfType<itemUI>().capShog = false;
                }
            }
       }
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
        if (GameObject.FindObjectOfType<itemUI>().escud == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[2] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[2].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[2];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[2] <= 0)//destiva o slot 0
            {
                GameObject.FindObjectOfType<armazenaItens>().slot[2].SetActive(false);
                GameObject.FindObjectOfType<itemUI>().escud = false;
            }

        }
        if (GameObject.FindObjectOfType<itemUI>().peitCour == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[3] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[3].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[3];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[3] <= 0)//destiva o slot 0
            {
                GameObject.FindObjectOfType<armazenaItens>().slot[3].SetActive(false);
                GameObject.FindObjectOfType<itemUI>().peitCour = false;
            }

        }
        if (GameObject.FindObjectOfType<itemUI>().relans == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[4] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[4].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[4];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[4] <= 0)//destiva o slot 0
            {
                GameObject.FindObjectOfType<armazenaItens>().slot[4].SetActive(false);
                GameObject.FindObjectOfType<itemUI>().relans = false;
            }

        }
        if (GameObject.FindObjectOfType<itemUI>().capShog == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[5] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[5].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[5];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[5] <= 0)//destiva o slot 0
            {
                GameObject.FindObjectOfType<armazenaItens>().slot[5].SetActive(false);
                GameObject.FindObjectOfType<itemUI>().capShog = false;
            }

        }
    }
    
}
