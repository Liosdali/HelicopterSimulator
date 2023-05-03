using Oyedoyin.RotaryWing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimationScript : MonoBehaviour
{

    public Animator anim;
    public GameObject _helicopter;
    public bool _oilButton = false;

    

    public void OilOpen()
    {
        _oilButton = !_oilButton;
        Debug.Log(_oilButton);
    }


    public void PlayKeyStartAnim()
    {
        if (anim.GetBool("KeyStart") != true && _oilButton)
        {
            _helicopter.GetComponent<RotaryController>().TurnOnEngines();
            anim.SetBool("KeyStart", true);
        }
        else
        {
            _helicopter.GetComponent<RotaryController>().TurnOffEngines();
            anim.SetBool("KeyStart", false);
        }
    }

    [ContextMenu("Test Engine On")]
    public void TestFunction()
    {
        _helicopter.GetComponent<RotaryController>().TurnOnEngines();
    }

}
