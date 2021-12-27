using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Vitoria : MonoBehaviour
{
     public string menuInicial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void telaPrincipal()
    {
        SceneManager.LoadScene(menuInicial);
    }
}
