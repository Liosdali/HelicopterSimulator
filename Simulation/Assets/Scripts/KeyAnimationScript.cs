using Oyedoyin.RotaryWing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimationScript : MonoBehaviour
{

    public Animator anim;
    public GameObject _helicopter;
    public bool _oilButton = true;

    

    public void OilOpen()
    {
        _oilButton = !_oilButton;
        Debug.Log(_oilButton);
    }

    private TutorialEnum type = TutorialEnum.keyOff;


    private bool m_tuto = false;
    private bool checkTuto = false;

    public void PlayKeyStartAnim()
    {
        if (!m_tuto)
        {
            m_tuto = Tutorial_Checker.Instance.KeyCheck(type);
            _oilButton = true;
        }
        if (anim.GetBool("KeyStart") != true && _oilButton)
        {            
            if (m_tuto)
            {
                    checkTuto = true;
                    anim.SetBool("KeyStart", true);
                    Invoke(nameof(TestFunction), 3.25f);
                    _helicopter.GetComponent<RotaryController>().TurnOnEngines();               
            }
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
