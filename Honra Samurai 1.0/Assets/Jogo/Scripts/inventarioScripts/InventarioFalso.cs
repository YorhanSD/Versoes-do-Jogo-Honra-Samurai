using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventarioFalso : MonoBehaviour
{
    [SerializeField]
    Item[] arrayInventory;
    public List<Item> Inventario {get; private set;}
    private void Awake()
    {
        Inventario = new List<Item>();
        Inventario = arrayInventory.OrderBy(i => i.Nome).ToList();
    }
    public void AddItem(Item item)
    {
        if(item != null)
        {
            Inventario.Add(item);
        }

    }
    public void RemoveItem(Item item)
    {
        if(item !=null)
        {
            Inventario.Remove(item);
        }
    }


}
