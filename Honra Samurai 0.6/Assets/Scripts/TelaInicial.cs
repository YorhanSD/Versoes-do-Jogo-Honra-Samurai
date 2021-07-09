using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour
{
    public string Cena;

    public GameObject painelConfiguracao;

    public GameObject painelControles;
        void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void iniciarJogo()
    {
        SceneManager.LoadScene(Cena);
    }

    public void configuracoes()
    {
        painelConfiguracao.SetActive(true);
    }
     public void controles()
    {
        painelControles.SetActive(true);
    }
    public void voltar()
    {
        painelConfiguracao.SetActive(false);
        painelControles.SetActive(false);
    }

    public void sairDoJogo()
    {
        //No Editor da Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();

    }
}
