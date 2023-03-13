using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierAnimation : MonoBehaviour
{
    private InputAction _inputA;
    public InputActionAsset inputActions;

    Animator animator;



    // Start is called before the first frame update
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        _inputA = inputActions.FindActionMap("XRI Wrist Menu").FindAction("DialogueSkip");
        _inputA.Enable();
        _inputA.performed += Toggleinput;

    }

    public void Toggleinput(InputAction.CallbackContext context)
    { 

        animator.SetBool("S_Pose",true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
