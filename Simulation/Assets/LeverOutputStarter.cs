using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oyedoyin.Common;


public class LeverOutputStarter : MonoBehaviour
{



    // ---------------------------- Events
    public UnityEvent onFlipOn = new UnityEvent();
    public UnityEvent onFlipOff = new UnityEvent();

    [SerializeField]
    private SilantroLever m_lever;


    private bool m_Open;

    // Update is called once per frame
    void Update()
    {
        if (m_lever.leverOutput > 0.8f)
        {
            onFlipOn.Invoke();
        }
        else
        {
            onFlipOff.Invoke();
        }


        if (!m_Open)
        {
            OutputOnCheck();
        }
        else
        {
            OutputOffCheck();
        }


    }

    private void OutputOffCheck()
    {
        if (m_lever.leverOutput < 0.78f)
        {
            m_Open = false;
            onFlipOn.Invoke();
        }
    }
    private void OutputOnCheck()
    {
        if (m_lever.leverOutput > 0.8f)
        {
            m_Open = true;
            onFlipOn.Invoke();
        }
    }
}
