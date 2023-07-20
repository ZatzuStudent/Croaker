using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPos;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPos = cameraTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPos;
        float speedBG = 0.5f;
        transform.position += deltaMovement * speedBG;
        lastCameraPos = cameraTransform.transform.position;
    }
}
