using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private Animator anim;
    private Movement movement;
    [SerializeField] float AttackCooldown;
    float colldownTimmer = Mathf.Infinity; 


    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();

    }


    void Update(){
        if(Input.GetMouseButton(0)&& colldownTimmer>AttackCooldown && movement.canAttack())
        {
            Attack();
        }
        colldownTimmer +=Time.deltaTime;



       Debug.Log(movement.canAttack());
    }

    private void Attack(){
        
        anim.SetTrigger ("attack");
        colldownTimmer = 0;

        
    }
    
    
}
