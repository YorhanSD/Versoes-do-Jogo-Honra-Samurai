using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Derrota : MonoBehaviour
{
    public string cena;
    public string menuInicial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reiniciar()
    {
        SceneManager.LoadScene(cena);
    }
    public void telaPrincipal()
    {
        SceneManager.LoadScene(menuInicial);
    }
}
