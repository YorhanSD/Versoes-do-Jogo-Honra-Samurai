using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class telaConfiguracoes : MonoBehaviour
{
    public GameObject painelConfiguracao;
    public GameObject painelControles;
    public GameObject painelResolucoes;
    public GameObject painelGraficos;

    public void configuracoes()
    {
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
        painelConfiguracao.SetActive(false);
        painelControles.SetActive(false);
        painelResolucoes.SetActive(false);
        painelGraficos.SetActive(false);
    }

    public void sairDoJogo()
    {
        //No Editor da Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();

    }
}
