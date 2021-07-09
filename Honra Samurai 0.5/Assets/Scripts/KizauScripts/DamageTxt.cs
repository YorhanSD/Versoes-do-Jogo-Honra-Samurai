using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DamageTxt : MonoBehaviour
{
    //public Text Damage;
    
    void Start()
    {
     Destroy (gameObject, 0.40f);
    }

    void Update()
    {
        
    }

    public void SetText(string value)
    {
     //Damage.text = value;
    }
}
