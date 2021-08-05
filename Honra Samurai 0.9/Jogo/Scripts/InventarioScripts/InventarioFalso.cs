using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventarioFalso : MonoBehaviour
{
    [SerializeField]
    Itens[] arrayInventory;
    public List<Itens> Inventario {get; private set;}
    private void Awake()
    {
        Inventario = new List<Itens>();
        Inventario = arrayInventory.OrderBy(i => i.Nome).ToList();
    }
    public void AddItem(Itens item)
    {
        if(item != null)
        {
            Inventario.Add(item);
        }

    }
    public void RemoveItem(Itens item)
    {
        if(item !=null)
        {
            Inventario.Remove(item);
        }
    }


}
