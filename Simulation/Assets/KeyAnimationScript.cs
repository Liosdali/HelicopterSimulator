using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimationScript : MonoBehaviour
{

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayStartAnim()
    {
        anim.SetTrigger("KeyStart");
    }

    public void PlayStopAnim()
    {
        anim.SetTrigger("KeyStop");
    }

}
