using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirItem : MonoBehaviour
{
    private AudioSource AudioS;
    public AudioClip somItem;
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
            AudioS.clip = somItem;
            AudioS.Play();
        }
    }
}
