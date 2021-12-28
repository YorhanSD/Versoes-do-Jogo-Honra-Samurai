using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class telaPause : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject inventario;
    public string menuInicial;
    public string reinicio;


    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //velocidade do jogo
            if(Time.timeScale == 1)
            {
                menuPause.SetActive(true);
                Time.timeScale = 0; 
            }
            else
            {
                menuPause.SetActive(false);
                Time.timeScale = 1;
            }

        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventario.SetActive(false);
        }
    }
    public void botaoPause()
    {
        //velocidade do jogo
        if(Time.timeScale == 1)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0; 
        }
        else
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    public void Botao_MenuInicial()
    {
        SceneManager.LoadScene(menuInicial);
    }
    public void Botao_Reinicio()
    {
        SceneManager.LoadScene(reinicio);
    }
    public void botaoInventario()
    {
        inventario.SetActive(true);   
    }
    public void botaoVoltar()
    {
       inventario.SetActive(false); 
    }

    public void voltar()
    {
       menuPause.SetActive(false);
       Time.timeScale = 1;
    }
}
