using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moeda : MonoBehaviour
{
    public int adicionaMoeda = 1;
   
    public void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<contaMoedas>().contaMoeda(adicionaMoeda);
            Destroy();   
        }
    }
     
    void Destroy()
    {
        Destroy(gameObject,0.2f);
    }
}
