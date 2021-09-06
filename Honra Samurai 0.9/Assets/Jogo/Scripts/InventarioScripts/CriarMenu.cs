using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarMenu : MonoBehaviour
{
    public ItemReferencia elemento;
    private List<Itens> inventario;
    void Start()
    {
        inventario = new List<Itens>();
        inventario = FindObjectOfType<InventarioFalso>().Inventario;
        InstantiateElements();
    }
private void InstantiateElements(){
    for (int i = 0; i < inventario.Count; i++)
    {
        if(IsRepeated(i))
        {
            continue;
        }
        (Instantiate(elemento, transform) as ItemReferencia).SetValues(inventario[i]);
    }
}

bool IsRepeated(int i){
    if (i == 0)
    return false;
    return inventario[i].ID == inventario[i -1].ID;
}

}
