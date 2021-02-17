using UnityEngine;
using UnityEngine.InputSystem;

public class CinamachineSwitcher : MonoBehaviour
{
    
    [SerializeField]
    private InputAction action;

    public Animator animator;

    private bool thirdPersonCam = true;


    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }


    void Start()
    {
        action.performed += _ => SwitchState();
    }

    private void SwitchState()
    {
        if(thirdPersonCam == true)
        {
            animator.Play("BBCam");
        }
        else
        {
            animator.Play("ThirdPersonCam");
        }
        thirdPersonCam = !thirdPersonCam;
    }

}
