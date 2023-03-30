using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimationScript : MonoBehaviour
{

    public Animator anim;


    public void PlayKeyStartAnim()
    {
        if(anim.GetBool("KeyStart") != true)
        {
            anim.SetBool("KeyStart", true);
        }
        else
        {
            anim.SetBool("KeyStart", false);
        }
    }

}
