using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class SwitchCover : MonoBehaviour
{
    public Animator anim;
    public GameObject switchTargetCollider;

    private bool inColl = false;
    

    // Start is called before the first frame update
    void Start()
    {
        switchTargetCollider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (!inColl)
            {
                anim.SetBool("IsHandInCollision", true);
            }
            else if(inColl)
            {
                anim.SetBool("IsHandInCollision", false);
            }
                 
        }
    }
        
           // anim.SetBool("IsHandInCollision", false);
    public void OpenSwitch()
    {
      GetComponent<BoxCollider>().enabled = false;
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
