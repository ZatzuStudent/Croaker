using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    private Animator anim;
    private SpriteRenderer sprite;
    public DistanceJoint2D _distanceJoint;
    public bool isAiming;
    private enum MovementState { idle, running, aim, falling, jumping }
    private MovementState state;



    public float decreaseStep = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        Line();
        Pull();
    }


    private void Line()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("Ground").GetComponent<Click>().isAttachable)
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
            Rotater();
            
            

            GameObject.Find("Frog").GetComponent<PlayerMovement>().enabled = false;
            
        }
        

        
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            RotaterReset();
            GameObject.Find("Frog").GetComponent<PlayerMovement>().enabled = true;
        }
        if (_distanceJoint.enabled) 
        {
            _lineRenderer.SetPosition(1, transform.position);
        }

    }

        private void Rotater()
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _distanceJoint.connectedAnchor = mousePos;
            Debug.Log("LOL");

                    var dir = mousePos;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                isAiming = true;
                state = MovementState.aim;
                anim.SetBool("isAiming", isAiming);


            sprite.flipX = false;
        }

        private void RotaterReset()
        {
            isAiming = false;
            anim.SetBool("isAiming", isAiming);
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        }
    

    private void Pull()
    {
        if (Input.GetMouseButton(1))
        {
            _distanceJoint.distance -= decreaseStep;
        }
    }
}