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

            // This can fix the collision problem but 
            // There wont be the closing switch option
            GetComponent<BoxCollider>().enabled = false;    

        }
        else
        {
            anim.SetBool("IsHandInCollision", false);
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
