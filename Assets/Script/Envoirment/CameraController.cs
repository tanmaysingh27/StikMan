using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D bodyPlayer;
    
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private  float lookahead;

    

    void Update()
    {   
                  
        transform.position = new Vector3(player.position.x+lookahead, player.position.y, transform.position.z);   

        if (bodyPlayer.velocity != Vector2.zero) 
        {
        lookahead = Mathf.Lerp(lookahead, aheadDistance, Time.deltaTime *cameraSpeed);
        }

        


    }
    }

