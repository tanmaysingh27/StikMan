using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftMovement : MonoBehaviour
{
      [SerializeField] private float movementDistance;
      [SerializeField] private float speed;
      private bool movingUp;
      private float top;
      private float bottom;  

      private void start()
      {
        top =  transform.position.y - movementDistance;
        bottom = transform.position.y + movementDistance;
      }
   


   private void Update()
   {
     if(movingUp)
     {
        if(transform.position.y > top)
        {
            transform.position =new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime,transform.position.z);
        }
        else
        movingUp = false;
     }
     else
     {
        if(transform.position.y < bottom)
        {
             transform.position =new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime,transform.position.z);
        }
        else
        movingUp = true;
     }
   }
}
