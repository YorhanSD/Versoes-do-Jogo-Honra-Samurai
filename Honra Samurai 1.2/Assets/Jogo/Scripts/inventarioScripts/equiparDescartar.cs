using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equiparDescartar : MonoBehaviour
{
    public int capacidade = 6;
    public GameObject equipar;
    public GameObject descartar;
    public GameObject telaEquipamentos;
    public GameObject inventario;
    public GameObject[] slotEquipamentos;

    public void Start()
    {
        

    }
    public void botaoEquipamentos()
    {
        telaEquipamentos.SetActive(true);
        inventario.SetActive(false);
    }
    public void botaoVoltar()
    {
        telaEquipamentos.SetActive(false);
    }
    public void botaoEquipar()
    {
       if(GetComponent<itemUI>().capAtlan == true)
       {
            if(capacidade > 0)//so pode equipar 1 capacete atlantis
            {
                capacidade -= 1;
                GameObject.FindObjectOfType<pegaItens>().Contador[0] -= 1;
                GameObject.FindObjectOfType<armazenaItens>().quantidade[0].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[0];
                GameObject.FindObjectOfType<playerControleAtaque>().capAtlantsEqui = true;
                Debug.Log("capacete atlantis foi equipado");
                slotEquipamentos[0].SetActive(true);
                //Ativa slot nos equipamentos
                //Limite de 1
                if (GameObject.FindObjectOfType<pegaItens>().Contador[0] <= 0)
                {
                    GameObject.FindObjectOfType<armazenaItens>().slot[0].SetActive(false);
                    GetComponent<itemUI>().capAtlan = false;
                }
            }
       }
       if(GetComponent<itemUI>().manop == true)
       {
           GameObject.FindObjectOfType<pegaItens>().Contador[1] -=1;
           GameObject.FindObjectOfType<armazenaItens>().quantidade[1].text= "x" + GameObject.FindObjectOfType<pegaItens>().Contador[1];
           GameObject.FindObjectOfType<playerControleAtaque>().manopEqui = true;
           Debug.Log("manopla dragonica foi equipada");
           if(GameObject.FindObjectOfType<pegaItens>().Contador[1] <= 0)
           {
           GameObject.FindObjectOfType<armazenaItens>().slot[1].SetActive(false);
           GetComponent<itemUI>().manop = false;
           } 
       }
       if(GetComponent<itemUI>().escud == true)
       {
           GameObject.FindObjectOfType<pegaItens>().Contador[2] -=1;
           GameObject.FindObjectOfType<armazenaItens>().quantidade[2].text= "x" + GameObject.FindObjectOfType<pegaItens>().Contador[2];
           GameObject.FindObjectOfType<playerControleAtaque>().escudEqui = true;
           Debug.Log("o lendario escudo de carvalho foi equipado");
           if(GameObject.FindObjectOfType<pegaItens>().Contador[2] <= 0)
           {
           GameObject.FindObjectOfType<armazenaItens>().slot[2].SetActive(false);
           GetComponent<itemUI>().escud = false;
           } 
       }
       if(GetComponent<itemUI>().peitCour == true)
       {
           GameObject.FindObjectOfType<pegaItens>().Contador[3] -=1;
           GameObject.FindObjectOfType<armazenaItens>().quantidade[3].text= "x" + GameObject.FindObjectOfType<pegaItens>().Contador[3];
           GameObject.FindObjectOfType<playerControleAtaque>().peitCourEqui = true;
           Debug.Log("o peitoral de couro foi equipado");
           if(GameObject.FindObjectOfType<pegaItens>().Contador[3] <= 0)
           {
           GameObject.FindObjectOfType<armazenaItens>().slot[3].SetActive(false);
           GetComponent<itemUI>().peitCour = false;
           } 
       }
       if(GetComponent<itemUI>().relans == true)
       {
           GameObject.FindObjectOfType<pegaItens>().Contador[4] -=1;
           GameObject.FindObjectOfType<armazenaItens>().quantidade[4].text= "x" + GameObject.FindObjectOfType<pegaItens>().Contador[4];
           GameObject.FindObjectOfType<playerControleAtaque>().relansEqui = true;
           Debug.Log("a relanspada foi equipada");
           if(GameObject.FindObjectOfType<pegaItens>().Contador[4] <= 0)
           {
           GameObject.FindObjectOfType<armazenaItens>().slot[4].SetActive(false);
           GetComponent<itemUI>().relans = false;
           } 
       }
        if(GetComponent<itemUI>().capShog == true)
       {
           GameObject.FindObjectOfType<pegaItens>().Contador[5] -=1;
           GameObject.FindObjectOfType<armazenaItens>().quantidade[5].text= "x" + GameObject.FindObjectOfType<pegaItens>().Contador[5];
           GameObject.FindObjectOfType<playerControleAtaque>().capShogEqui = true;
           Debug.Log("o capacete do shogum foi equipado");
           if(GameObject.FindObjectOfType<pegaItens>().Contador[5] <= 0)
           {
           GameObject.FindObjectOfType<armazenaItens>().slot[5].SetActive(false);
           GetComponent<itemUI>().capShog = false;
           } 
       }
    }
    public void botaoDescartar()
    {
        if (GetComponent<itemUI>().capAtlan == true)
        {
            GameObject.FindObjectOfType<pegaItens>().Contador[0] -= 1;
            GameObject.FindObjectOfType<armazenaItens>().quantidade[0].text = "x" + GameObject.FindObjectOfType<pegaItens>().Contador[0];
            Debug.Log("capacete atlantis foi descartado");
            if (GameObject.FindObjectOfType<pegaItens>().Contador[0] <= 0)//destiva o slot 0
            {
               GameObject.FindObjectOfType<armazenaItens>().slot[0].SetActive(false);
               GetComponent<itemUI>().capAtlan = false;
            }
            
        }
    }
    
}
