using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipamentos : MonoBehaviour
{
    
    public GameObject[] slotEquipado;
    public bool capAtlant = false;

    public void botaoCapAtlant()
    {
        capAtlant = true;
    }

    public void desequipar()
    {
        if(capAtlant == true)
        {
            slotEquipado[0].SetActive(false);
            Debug.Log("voce desequipou o capacete atlantis");
            //GameObject.FindObjectOfType<equiparDescartar>().capacidade =+ 1;
        }

    }
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }
}
