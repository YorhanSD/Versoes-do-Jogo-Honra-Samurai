using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Criar Item")]
public class Item: ScriptableObject
{
  public Texture2D Icone;
  public string Nome;
  public string Descricao;
  
}
