using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEditor;
using Oyedoyin.Common;
using Oyedoyin;

public class SwitchCover : MonoBehaviour
{
    public Animator anim;
    public GameObject switchTargetCollider;
    private bool inColl = false;
    public SilantroHand m_controller;

    void Start()
    {
        switchTargetCollider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {

            if (m_controller == null)
            {
                m_controller = other.GetComponent<SilantroHand>();
            }
            //If Player Touches it will change the 
            //switch_Hit = true;
            if (m_controller != null)
            {

                //m_controller.SetAnimBool(true);
                //m_Hand.SetActive(true);

                if (m_controller.gripValue > 0.9f)   //if (m_controller.triggerValue > 0.9f && m_controller.gripValue > 0.9f)
                {
                    Debug.Log("AAAAAAXXXAXXAXAXA");
                        ToggleTrigger();
                }
            }

        }
    }
        
    public void ToggleTrigger()
    {

        Debug.LogWarning("Uyarý");
        
        if (!inColl)
        {
            anim.SetBool("IsHandInCollision", true);
            Debug.LogWarning("True");
        }
        else if (inColl)
        {
            anim.SetBool("IsHandInCollision", false);
            Debug.LogWarning("False");
        }   

    }


           // anim.SetBool("IsHandInCollision", false);
    public void OpenSwitch()
    {
      //GetComponent<BoxCollider>().enabled = false;
      switchTargetCollider.SetActive(true);
        inColl = !inColl;
    }

    public void CloseSwitch()
    {
        GetComponent<BoxCollider>().enabled = true;
        switchTargetCollider.SetActive(false);
        inColl= !inColl;
    }

}
