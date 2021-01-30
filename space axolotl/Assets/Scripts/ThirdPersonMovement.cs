using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public Transform cam;

    private float gravity = 9.81f;
    private float jumpSpeed = 3.5f;
    private float doubleJumpMultiplier = 0.5f;
    private float directionY;
    private bool canDoubleJump = false;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

  //  public Rigidbody rb;
  //  public bool cubeIsOnGround = true;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);


        if (controller.isGrounded)
        {
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed;

                
            }
        } else 
            {
                if(Input.GetButtonDown("Jump") && canDoubleJump) 
                {
                     directionY = jumpSpeed * doubleJumpMultiplier;
                     canDoubleJump = false;
                }
                
            }

         if (direction.magnitude >=0.1f && !controller.isGrounded)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform .rotation = Quaternion.Euler(0f, angle,0f); 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            directionY -= gravity * Time.deltaTime;
            direction.y = directionY;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
       else 
        {
            //directionY -= gravity * Time.deltaTime;
            //direction.y = directionY;
            //controller.Move(direction * speed * Time.deltaTime);
        }
        

        Debug.Log(direction.magnitude);
    }

    
}
