using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Criar Item")]
public class Itens : ScriptableObject
{
  public Texture2D Icone;
  public string Nome;
  public string Descricao;
  public int ID {get; private set;}

  public int Count {get { 
      return 
      FindObjectOfType<InventarioFalso>().Inventario.FindAll(x => x.ID == this.ID).Count;
   }
  }
  public void OnEnable()
  {
    ID = this.GetInstanceID();
  }
}
