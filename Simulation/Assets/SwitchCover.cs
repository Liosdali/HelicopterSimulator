using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEditor;

public class SwitchCover : MonoBehaviour
{
    public Animator anim;
    public GameObject switchTargetCollider;
    private bool inColl = false;

    void Start()
    {
        switchTargetCollider.SetActive(false);
    }
    
    public void ToggleTrigger()
    {
        if (!inColl)
        {
            anim.SetBool("IsHandInCollision", true);
           Debug.LogWarning("True");
        }

        //if (!inColl)
        //{
        //    anim.SetBool("IsHandInCollision", true);
        //    Debug.LogWarning("True");
        //}
        //else if (inColl)
        //{
        //    anim.SetBool("IsHandInCollision", false);
        //    Debug.LogWarning("False");
        //}
    }

    public void OffTrigger()
    {
        if (inColl)
        {
            anim.SetBool("IsHandInCollision", false);
            Debug.LogWarning("False");
        }

    }

    public void OpenSwitch()
    {
      switchTargetCollider.SetActive(true);
        inColl = !inColl;
    }

    public void CloseSwitch()
    {
        switchTargetCollider.SetActive(false);
        inColl= !inColl;
    }

}
