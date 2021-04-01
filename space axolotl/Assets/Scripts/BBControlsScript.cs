using UnityEngine;
using UnityEngine.InputSystem;

public class BBControlsScript : MonoBehaviour
{
    public InputActionReference BBmovementControl;
    public InputActionReference BBjumpControl;
    public InputActionReference BBclimbControl;
    public CharacterController controller;
    PlayerControls Input;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    Transform cameraMainTransform;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public Animator animator;
    private float playerSpeed = 6.0f;
    //private float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 4f;
    private bool isWalking = false;
    //private bool isJumping = false;
    private float animationFinishTime = 0.9f;
    public GameObject SDcamera;
    public BoxCollider groundCheck;

    private bool isClimbing = false;

    void Awake()
    {
       Input = new PlayerControls();

    }


     void OnTriggerEnter(Collider other)
    {
        
        if (other.tag==("RockWall"))
        {
            BBclimbControl.action.Enable();
            GameObject Child = other.transform.GetChild(0).gameObject;
            GetComponent<BBClimbingLerp>().End = Child;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag==("RockWall"))
        {
             BBclimbControl.action.Disable();
        }
    }

 /*  public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.tag == "Ground")
        {
            groundedPlayer = true;
        }  
    }

    public void OnTriggerExit (Collider other)
    {
         Debug.Log("trigger exit");
        groundedPlayer = false;
    }
*/

    private void OnEnable()
    {
        BBmovementControl.action.Enable();
    //    BBjumpControl.action.Enable();
    }

    private void OnDisable()
    {
        BBmovementControl.action.Disable();
    //    BBjumpControl.action.Disable();
    }

    private void Start()
    {
        cameraMainTransform = Camera.main.transform;

    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = BBmovementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward *move.z + cameraMainTransform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
       /* if (BBjumpControl.action.triggered && groundedPlayer)
        {
            AnimateJump();
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        
        AnimateWalk(movement);
       

/*if (!groundedPlayer || BBjumpControl.action.triggered)
         {
            animator.SetTrigger("isJumping");
         }
            else 
            {
                animator.ResetTrigger("isJumping");
            }*/
    

    void AnimateWalk(Vector3 movement)
    {
        isWalking = (movement.x >0.1f || movement.x < -0.1) || (movement.y >0.1f || movement.y < -0.1) ? true : false;
        animator.SetBool("isWalking", isWalking);
    }

    if (BBclimbControl.action.triggered)
        {
            Debug.Log("triggered");
            gravityValue = 0f;
            GetComponent<BBClimbingLerp>().enabled = true;
            animator.SetTrigger("isClimbing");
        }
        else 
        {
            //GetComponent<ClimbingLerp>().enabled = false;
            animator.ResetTrigger("isClimbing");
        }

     if(GetComponent<BBClimbingLerp>().enabled == true)
        {
            OnDisable();
        }
        else
        {
            OnEnable();
            
        }

    }
}
