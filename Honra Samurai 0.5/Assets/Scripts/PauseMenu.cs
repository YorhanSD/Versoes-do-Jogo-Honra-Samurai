using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPause;
   
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
    }
    public void voltar()
    {
       menuPause.SetActive(false);
       Time.timeScale = 1;
    }
}
