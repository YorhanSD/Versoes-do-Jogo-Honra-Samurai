using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public int danoEspinhos = 40;
 
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<KizauControleDeDano>().danoESP(danoEspinhos);
        }
    }
    
}
