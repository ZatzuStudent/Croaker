using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finsh : MonoBehaviour
{    
    public BoxCollider2D triggerCollider;
    public GameObject endCard;

    void Start()
    {
        endCard.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            endCard.SetActive(true);

           
        }

    }

}
