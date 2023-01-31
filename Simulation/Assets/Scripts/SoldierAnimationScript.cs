using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierAnimationScript2 : MonoBehaviour
{
    private InputAction _inputA;
    public InputActionAsset inputActions;

    // Start is called before the first frame update
    void Start()
    {
        _inputA = inputActions.FindActionMap("XRI Wrist Menu").FindAction("DialogueSkip");
        _inputA.Enable();
        _inputA.performed += Toggleinput();
        
    }

    private void Toogleinput()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
