using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curaVida : MonoBehaviour
{
    public int potencialCura = 50;
    public AudioClip somCura;
    private AudioSource AS;
     void Start()
    {
        AS = GetComponent<AudioSource>();

    }

    public void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
            _Player.GetComponent<KizauControleDeDano>().cura(potencialCura);
            AS.clip = somCura;
            AS.Play();
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(gameObject,1.2f);
    }
}
