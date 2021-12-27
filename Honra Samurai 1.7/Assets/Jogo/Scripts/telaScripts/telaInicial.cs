using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class telaInicial : MonoBehaviour
{
    public string nomeCena;
    private AudioSource audioS;
    public AudioClip somClickStart;
    public AudioClip somClick;
    public GameObject painelConfiguracao;
    public GameObject painelControles;
    public GameObject painelResolucoes;
    public GameObject painelGraficos;

    void Start()
    {
      audioS = GetComponent<AudioSource>();
    }

    public void iniciarJogo()
    {
        audioS.clip = somClickStart;
        audioS.Play();
        SceneManager.LoadScene(nomeCena);
    }
    public void configuracoes()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelConfiguracao.SetActive(true);
    }
     public void controles()
    {
        painelControles.SetActive(true);
    }
    public void resolucoes()
    {
        painelResolucoes.SetActive(true);
    }
    public void graficos()
    {
        painelGraficos.SetActive(true);
    }
    public void voltar()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelConfiguracao.SetActive(false);
        painelControles.SetActive(false);
        painelResolucoes.SetActive(false);
        painelGraficos.SetActive(false);
    }

    public void sairDoJogo()
    {
        audioS.clip = somClick;
        audioS.Play();
        //No Editor da Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();

    }
}
