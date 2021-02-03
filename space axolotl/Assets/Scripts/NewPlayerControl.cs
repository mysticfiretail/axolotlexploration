using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerControl : MonoBehaviour
{
    public InputActionReference movementControl;
    public InputActionReference jumpControl;
    public InputActionReference crouchControl;
    public CharacterController controller;
    public BoxCollider head;
    public BoxCollider body;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Transform cameraMainTransform;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;


    private float playerSpeed = 6.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float rotationSpeed = 4f;
    float originalHeight;
    public float crouchHeight;



    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        crouchControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        crouchControl.action.Disable();
    }

    private void Start()
    {
       // controller = gameObject.AddComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward *move.z + cameraMainTransform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }


        if(crouchControl.action.triggered)
         {
             Crouch();
         }
        else
         {
            goUp();
         }

    }

    void Crouch()
        {

        }

    void goUp()
        {
 
        }

    
}

