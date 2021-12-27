using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCrateraControle : MonoBehaviour
{
    private Vector2 direcao;
    public int danoCratera = 2;
    public int danoMaximo = 200;
    public Animator chamarAnim;
    
     void Start()
    {
        danoCratera = 2;
        danoMaximo = 200;
        
        Destroy (gameObject, 6);
    }
    public void Inicializar(Vector2 _direcao)
    { 
       direcao = _direcao;
    }
   public void danoCratCirculoM(GameObject circuloM)
   {
        StartCoroutine(chamarDanoCirculoM(circuloM));
   }
    public void danoCrat(GameObject inimigo)
    {
        StartCoroutine(chamarDano(inimigo));
    }
   public void danoCratIII(GameObject inimigoIII)
   {
    StartCoroutine(chamarDanoIII(inimigoIII));
   }
   public IEnumerator chamarDanoCirculoM(GameObject circuloM)
    {
        while (danoCratera <= danoMaximo)
        {
            chamarCM(circuloM);
            danoCratera += 3;
            yield return new WaitForSeconds(1);
        }
   }
    public IEnumerator chamarDano(GameObject inimigo)
   {
           while (danoCratera <= danoMaximo)
           {
                chamar(inimigo);
                danoCratera += 5;
                yield return new WaitForSeconds(1);
           }
   }
    public IEnumerator chamarDanoIII(GameObject inimigoIII)
   {
       while(danoCratera <= danoMaximo)
       {
        chamarIII(inimigoIII);  
        danoCratera += 10;
        yield return new WaitForSeconds(1);
       }
   }
    public void chamarCM(GameObject circuloM)
    {
    circuloM.GetComponent<cmControleDano>().cm_LevaDanoCratera(danoCratera);
    }
    public void chamar(GameObject inimigo)
    {
      inimigo.GetComponent<inimigoControleDano>().danoContinuo(danoCratera);
    }
    public void chamarIII(GameObject inimigoIII)
    {
    inimigoIII.GetComponent<InimigoIIIControleDano>().danoContinuoIII(danoCratera);
    }
}
