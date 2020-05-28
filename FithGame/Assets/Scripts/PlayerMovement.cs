using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;


    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private int desiredLane = 1; // 0:left 1:middle 2: right
    public float laneDistance = 6; // the distance between two lanes

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
     void Update()
    {
       // direction.z = forwardSpeed;




        //Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    desiredLane++;
        //    if (desiredLane == 3)
        //    {
        //        desiredLane = 2;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    desiredLane--;
        //    if (desiredLane == -1)
        //    {
        //        desiredLane = 0;
        //    }
        //}

        //Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        //if (desiredLane == 0)
        //{
        //    targetPosition += Vector3.left * laneDistance;
        //}
        //else if (desiredLane == 2)
        //{
        //    targetPosition += Vector3.right * laneDistance;
        //}

        //transform.position = targetPosition;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       // controller.Move(direction * Time.fixedDeltaTime);
        // Add a forwardForce
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.Impulse
                );
        }





    }
}
