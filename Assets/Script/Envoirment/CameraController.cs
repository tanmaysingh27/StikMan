using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Movement playerMove;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D bodyPlayer;
    
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private  float lookahead;
   [SerializeField] private float zoomSpeed;
   
   [SerializeField] private float maxZoom;
   [SerializeField] private float minZoom;
   [SerializeField] private Camera cam;
   private float uproom;
   

    

    void Update()
    {   
                  
        transform.position = new Vector3(player.position.x+lookahead, player.position.y+uproom, transform.position.z);   
        
        if(playerMove.isGrounded() == false)
        {
            cam.orthographicSize += zoomSpeed;
            if(cam.orthographicSize > maxZoom)
            {
               cam. orthographicSize = maxZoom;
            }
        }

        if(playerMove.isGrounded())
        {
        cam.orthographicSize -= zoomSpeed;
            if(cam.orthographicSize < minZoom)
            {
               cam. orthographicSize = minZoom;
            }
        }

        if (bodyPlayer.velocity != Vector2.zero) 
        {
        lookahead = Mathf.Lerp(lookahead, aheadDistance, Time.deltaTime *cameraSpeed);
        }

}
}





    

        



