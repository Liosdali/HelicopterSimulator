using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEditor;

public class InteractionInstigator : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction _trigger;

    private List<Interactable> m_NearbyInteractables = new List<Interactable>();

    public bool HasNearbyInteractables()
    {
        return m_NearbyInteractables.Count != 0;
    }
    private void Start()
    {
        _trigger = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Activate");
        _trigger.Enable();
    }
    private void Update()
    {
    
    }
    public void ToogleTrigger(InputAction.CallbackContext context)
    {
        if (HasNearbyInteractables())
        {
            Debug.Log("Trigger button is pressed.");
            //Ideally, we'd want to find the best possible interaction (ex: by distance & orientation).
            m_NearbyInteractables[0].DoInteraction();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Interactable interactable = gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            Debug.Log("Colliding with = " + other.gameObject.name);
            m_NearbyInteractables.Add(interactable);
 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(" Trigger got activated by" +other.gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            m_NearbyInteractables.Remove(interactable);
        }
    }
}