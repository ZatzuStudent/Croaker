using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HissTrig : MonoBehaviour
{

    public BoxCollider2D triggerCollider;
    [SerializeField] private AudioSource hiss;

    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hiss.Play();
           
        }

    }
}
