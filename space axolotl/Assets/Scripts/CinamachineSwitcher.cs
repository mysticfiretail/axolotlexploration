using UnityEngine;
using UnityEngine.InputSystem;

public class CinamachineSwitcher : MonoBehaviour
{
    
    [SerializeField]
    private InputAction action;
    public InputActionReference ThirdPersonMov;
    public InputActionReference ThirdPersonJump;
    public InputActionReference ThirdPersonCrouch;
    public InputActionReference BBControlsMov;
    public InputActionReference BBControlsJump;
    public GameObject Player;
    public GameObject BeepBoop;

    public Animator animator;

    public bool thirdPersonCam = true;



    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }


    private void OnEnableTPPlayer()
    {
        ThirdPersonMov.action.Enable();
        ThirdPersonJump.action.Enable();
        ThirdPersonCrouch.action.Enable();
    }

      private void OnDisableTPPlayer()
    {
        ThirdPersonMov.action.Disable();
        ThirdPersonJump.action.Disable();
        ThirdPersonCrouch.action.Disable();
    }

    private void OnDisableBBPlayer()
    {
        BBControlsMov.action.Enable();
        BBControlsJump.action.Enable();
    }

       private void OnEnableBBPlayer()
    {
        BBControlsMov.action.Disable();
        BBControlsJump.action.Disable();
    }

    void Start()
    {
        action.performed += _ => SwitchState();
        BeepBoop.GetComponent<BBControlsScript>().enabled = false; 
    }

    private void SwitchState()
    {
        if(thirdPersonCam == true)
        {
            animator.Play("BBCam");
            Player.GetComponent<NewPlayerControl>().enabled = false; 
            BeepBoop.GetComponent<BBControlsScript>().enabled = true; 
        }
        else
        {
            animator.Play("ThirdPersonCam");
            Player.GetComponent<NewPlayerControl>().enabled = true; 
            BeepBoop.GetComponent<BBControlsScript>().enabled = false; 
        }
        thirdPersonCam = !thirdPersonCam;
    }

}
