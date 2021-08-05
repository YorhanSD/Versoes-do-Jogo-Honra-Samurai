using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReferencia : MonoBehaviour
{
   public RawImage Icone;
   public Text CountText;
   public Itens _Item{ get; private set;}
   public void SetValues(Itens item)
   {
       _Item = item;
       Icone.texture = item.Icone;
       atualizaContagem();
   }
   private void atualizaContagem()
   {
    CountText.text = "x" +_Item.Count.ToString();
   }

}
