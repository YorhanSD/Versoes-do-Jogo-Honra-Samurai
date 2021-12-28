using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinhosControle : MonoBehaviour
{
    public int danoEspinhos = 40;
    void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<playerControleDano>().danoESP(danoEspinhos);
        }
    }
    
}
