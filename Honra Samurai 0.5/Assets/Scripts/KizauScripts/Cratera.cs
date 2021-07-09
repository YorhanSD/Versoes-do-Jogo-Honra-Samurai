using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cratera : MonoBehaviour
{
    private Vector2 direcao;
    public int danoCratera = 2;
    public int danoMaximo = 200;
    public Animator chamarAnim;
    public float tempoDanoContinuo = 0.5f;
    public float tempoDeDestruicao;
     void Start()
    {
        danoCratera = 2;
        danoMaximo = 200;
        tempoDeDestruicao = 4f;
        Destroy (gameObject, tempoDeDestruicao);
    }
    public void Inicializar(Vector2 _direcao)
    { 
       direcao = _direcao;
    }
   
   public void danoCrat(GameObject inimigo)
   {
    StartCoroutine(chamarDano(inimigo));
   }
   public IEnumerator chamarDano(GameObject inimigo)
   {
       while(danoCratera <= danoMaximo)
       {
        chamar(inimigo);  
        danoCratera += 10;
        yield return new WaitForSeconds(tempoDanoContinuo);
       }
   }
    public void chamar(GameObject inimigo){
    inimigo.GetComponent<InimigoControleDeDano>().danoContinuo(danoCratera);
       
   }
}
