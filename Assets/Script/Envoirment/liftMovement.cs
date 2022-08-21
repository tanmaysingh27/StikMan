using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftMovement : MonoBehaviour
{
        private Rigidbody2D body;
    void Start()
    {
        
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        for (float j = -2f; j < 5.01f; j+=0.0000000000001f)
        {
            body.transform.localPosition =new Vector3(-9.5f,j,0);
        }
    
    }
}
