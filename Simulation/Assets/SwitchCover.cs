using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEditor;
using Oyedoyin.Common;

public class SwitchCover : MonoBehaviour
{
    public Animator anim;
    public GameObject switchTargetCollider;
    private bool inColl = false;
    private SilantroButton m_SwitchScript;

    private bool tutoCheck = false;

    private TutorialEnum type = TutorialEnum.switchCover;

    void Start()
    {
        switchTargetCollider.SetActive(false);
        m_SwitchScript = GetComponent<SilantroButton>();
    }
    
    public void ToggleTrigger()
    {
        if (!inColl)
        {
            if (!tutoCheck)
            {
                Tutorial_Checker.Instance.NextTutorialObjective(type);
                tutoCheck = true;
            }
                anim.SetBool("IsHandInCollision", true);
                m_SwitchScript.SwitchFunction();
            // This can fix the collision problem but 
            // There wont be the closing switch option
            //GetComponent<BoxCollider>().enabled = false;    

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
