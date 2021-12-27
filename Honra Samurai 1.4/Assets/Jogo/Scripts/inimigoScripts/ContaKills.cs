using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaKills : MonoBehaviour
{
    public Text contaKills;
    public int kill = 0;
   
    public void contadorKill(int adicionaKill)
    {
        kill += adicionaKill;
        contaKills.text =  "Kills: " + kill;
    }
}
