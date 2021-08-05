using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curaVida : MonoBehaviour
{
    public int potencialCura = 50;
    public void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<KizauControleDeDano>().cura(potencialCura);
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(gameObject,0.2f);
    }
}
