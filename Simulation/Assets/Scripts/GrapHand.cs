using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrapHand : MonoBehaviour
{
    public Hand_Data leftHandPose;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetupPose);

        leftHandPose.gameObject.SetActive(false); 
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactor is XRDirectInteractor)
        {
            Hand_Data handData = arg.interactorObject.transform.GetComponentInChildren<Hand_Data>();
            handData.animator.enabled= false;
        }
        
    }
}
