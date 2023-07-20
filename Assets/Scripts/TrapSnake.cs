using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSnake : MonoBehaviour
{    
    bool isSnake;
    public Animator animator; 
    public BoxCollider2D triggerCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            animator.SetBool("isSnake", true);

            
        }

    }

}