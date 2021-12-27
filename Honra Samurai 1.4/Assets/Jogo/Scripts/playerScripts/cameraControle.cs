using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControle : MonoBehaviour
{ 
    public GameObject Target;
    public float Speed;

    void Update()
    {
        if(Target !=null)
        {
         transform.position = Vector2.Lerp (transform.position,Target.transform.position,Time.deltaTime * Speed);
        }
    }
}
