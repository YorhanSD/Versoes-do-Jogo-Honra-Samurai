using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{ 
    public GameObject Target;
    public float Speed;


     void Start()
    {
        
    }

  
    void Update()
    {
        if(Target !=null)
        {
         transform.position = Vector2.Lerp (transform.position,Target.transform.position,Time.deltaTime * Speed);
        }
    }
}
