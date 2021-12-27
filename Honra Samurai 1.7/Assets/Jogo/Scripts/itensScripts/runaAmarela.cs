using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runaAmarela : MonoBehaviour
{
     public string vitoria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D _Player)
    {
        if (_Player.gameObject.tag == "Player")
        {
           SceneManager.LoadScene(vitoria);
        }
    }
}
