using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerControl : MonoBehaviour
{
    public InputActionReference movementControl;
    public InputActionReference jumpControl;
    public InputActionReference crouchControl;
    public InputActionReference interactControl;
    public InputActionReference climbControl;
    public CharacterController controller;
    PlayerControls Input;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Transform cameraMainTransform;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public Animator animator;
    private float playerSpeed = 6.0f;
    private float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 4f;
    float originalHeight;
    public float crouchHeight;
    public bool crouchPressed;
    private bool isWalking = false;
    private bool isCrouching = false;
    private bool isJumping = false;
    private bool isClimbing = false;
    private float animationFinishTime = 0.9f;

    [SerializeField]
    GameObject interactableObject;


    void Awake()
    {
       Input = new PlayerControls();
       Input.Player.Crouch.performed += ctx=> crouchPressed = ctx.ReadValueAsButton();
    }

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
        originalHeight = controller.height; 
    }

    void OnTriggerEnter(Collider other)
    {
        interactControl.action.Enable();
        if (other.tag==("Ladder"))
        {
            climbControl.action.Enable();
            GameObject Child = other.transform.GetChild(0).gameObject;
            GetComponent<ClimbingLerp>().End = Child;
        }
    }

    void OnTriggerExit(Collider other)
    {
        interactControl.action.Disable();
        if(other.tag==("Ladder"))
        {
             climbControl.action.Disable();
        }
    }

    

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
 if(groundedPlayer)
    {
        animator.ResetTrigger("isJumping");
    }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward *move.z + cameraMainTransform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            animator.SetTrigger("isJumping");
            Debug.Log(isJumping);
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

        
        AnimateWalk(movement);
       

        if (interactControl.action.triggered)
        {
            Totem totem = interactableObject.GetComponent<Totem>();
            totem.OnInteract();
        }

        if (climbControl.action.triggered)
        {
            Debug.Log("triggered");
            gravityValue = 0f;
            GetComponent<ClimbingLerp>().enabled = true;
            animator.SetTrigger("isClimbing");
        }
        else 
        {
            //GetComponent<ClimbingLerp>().enabled = false;
            animator.ResetTrigger("isClimbing");
        }

        if(GetComponent<ClimbingLerp>().enabled == true)
        {
            OnDisable();
        }
        else
        {
            OnEnable();
        }

   if (crouchControl.action.triggered)
         {
        if(controller.height == crouchHeight)
            {
                animator.ResetTrigger("isCrouching");
                controller.center = new Vector3(0, 0.99f, 0);
                controller.height = originalHeight;
            }
            else 
            {
                controller.height = crouchHeight;
                controller.center = new Vector3(0, 0.46f, 0);
                animator.SetTrigger("isCrouching");
            }

         }

 

      /*  if(crouchPressed == true)
         {
             controller.height = crouchHeight;
             
             Debug.Log("crouch");
         }
        else if(!crouchPressed)
        {
            controller.height = originalHeight;
          //  Debug.Log("up");
        } 
*/
    
    if(isCrouching && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= animationFinishTime)
    {
        isCrouching = false;
    }

    }
    

    void AnimateWalk(Vector3 movement)
    {
        isWalking = (movement.x >0.1f || movement.x < -0.1) || (movement.y >0.1f || movement.y < -0.1) ? true : false;
        animator.SetBool("isWalking", isWalking);
    }


    void Crouching ()
    {
        if(!isCrouching)
        {
            animator.SetTrigger("isCrouching");
            StartCoroutine(InitialiseCrouch());
        }
    }

    IEnumerator InitialiseCrouch ()
    {
        yield return new WaitForSeconds(0.1f);
        isWalking = true; 
    }

    void Crouch()
        {
            controller.height = crouchHeight;
        }

    void goUp()
        {
            controller.height = originalHeight;
        }

}

