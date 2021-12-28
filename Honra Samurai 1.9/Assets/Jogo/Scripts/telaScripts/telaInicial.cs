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
    public GameObject painelCreditos;

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
        audioS.clip = somClick;
        audioS.Play();
        painelControles.SetActive(true);
    }
    public void resolucoes()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelResolucoes.SetActive(true);
    }
    public void graficos()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelGraficos.SetActive(true);
    }

    public void Creditos()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelCreditos.SetActive(true);
    }

    public void voltar()
    {
        audioS.clip = somClick;
        audioS.Play();
        painelConfiguracao.SetActive(false);
        painelControles.SetActive(false);
        painelResolucoes.SetActive(false);
        painelGraficos.SetActive(false);
        painelCreditos.SetActive(false);
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
