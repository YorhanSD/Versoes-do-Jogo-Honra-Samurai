using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaGraficos : MonoBehaviour
{
   public void BotaoInsano()
   {
    QualitySettings.SetQualityLevel (6);
   }
   public void BotaoUltra()
   {
    QualitySettings.SetQualityLevel (5);
   }
   public void BotaoAlto()
   {
    QualitySettings.SetQualityLevel (4);
   }
   public void BotaoMedio()
   {
    QualitySettings.SetQualityLevel (3);
   }
   public void BotaoBaixa()
   {
    QualitySettings.SetQualityLevel(2);
   }
}
