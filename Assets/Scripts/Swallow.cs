using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swallow : MonoBehaviour
{
    public BoxCollider2D triggerCollider;
    [SerializeField] private AudioSource swallow;
    public GameObject grasshopper;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(grasshopper);

            swallow.Play();
           
        }

    }
}

