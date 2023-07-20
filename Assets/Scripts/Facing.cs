using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public DistanceJoint2D _distanceJoint;
    public Camera mainCamera;
    void Start()
    {

    }
    private void Update()
    {
        Clicked();
        

    }

    private void Clicked()
    {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _distanceJoint.connectedAnchor = mousePos;
            Debug.Log("LOL");

                    var dir = mousePos;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}