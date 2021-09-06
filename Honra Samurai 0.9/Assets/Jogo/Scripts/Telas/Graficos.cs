using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graficos : MonoBehaviour
{
   public void insano()
   {
    QualitySettings.SetQualityLevel (6);
   }
   public void ultra()
   {
    QualitySettings.SetQualityLevel (5);
   }
   public void alto()
   {
    QualitySettings.SetQualityLevel (4);
   }
   public void medio()
   {
    QualitySettings.SetQualityLevel (3);
   }
}
