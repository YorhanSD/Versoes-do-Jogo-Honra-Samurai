using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Void : MonoBehaviour
{
    public string nomeTelaDerrota;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.name == "Kizau")
        {
            SceneManager.LoadScene(nomeTelaDerrota);
        }
    }
}
