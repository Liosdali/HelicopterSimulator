using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionInstigator : MonoBehaviour
{
    private List<Interactable> m_NearbyInteractables = new List<Interactable>();

    public bool HasNearbyInteractables()
    {
        return m_NearbyInteractables.Count != 0;
    }

    private void Update()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        UnityEngine.XR.InputDevice device = rightHandDevices[0];
        Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        bool triggerValue;
        if (HasNearbyInteractables() && device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
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