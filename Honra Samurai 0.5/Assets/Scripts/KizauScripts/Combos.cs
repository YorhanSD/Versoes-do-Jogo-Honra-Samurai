using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    public Animator anim;
    public int numberOfClicks = 0; // Número de Clicks
    public float  lastTimeYouClicked = 0f; // Última Vez que Você Clicou
    public float interval = 3f; // Tempo de Intervalo dos Combos

    void Start()
    {
      anim.gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Time.time - lastTimeYouClicked > interval)
        {
          numberOfClicks = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
          lastTimeYouClicked = Time.time;
          numberOfClicks ++;

          if(numberOfClicks == 1)
          {
               anim.SetBool("Attack", true);
          }
          numberOfClicks = Mathf.Clamp(numberOfClicks, 0 ,2);
        }
    }


    public void return1()
    {
        if(numberOfClicks >= 2)
        {
            anim.SetBool("Attack2", true);
        }
        else
        {
            anim.SetBool("Attack", false);
            numberOfClicks = 0;
        }

    }

    public void return2()
    {
    anim.SetBool("Attack2", false);
    anim.SetBool("Attack", false);
    numberOfClicks = 0;
    }

}
