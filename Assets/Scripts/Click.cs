using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public bool isAttachable = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
        {
        isAttachable = true;
        }

        else 
        {
            isAttachable = false;
            Debug.Log("NOPE");
        }
        }
    }

}