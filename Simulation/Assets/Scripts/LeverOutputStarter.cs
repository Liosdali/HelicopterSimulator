using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oyedoyin.Common;


public class LeverOutputStarter : MonoBehaviour
{


    [SerializeField]
    private SilantroLever m_lever;
    // ---------------------------- Events
    public UnityEvent onFlipOn = new UnityEvent();
    public UnityEvent onFlipOff = new UnityEvent();



    private TutorialEnum type = TutorialEnum.switchOff;


    private bool m_Open = false;
    private bool m_tuto = false;
    // Update is called once per frame
    void Update()
    {
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
            onFlipOff?.Invoke();
        }
    }
    private void OutputOnCheck()
    {

        if (!m_tuto)
        {
            m_tuto = Tutorial_Checker.Instance.NextTutorialObjective(type);
        }
        else if (m_tuto)
        {
            if (m_lever.leverOutput > 0.8f)
            {
                m_Open = true;
                onFlipOn?.Invoke();
            }
        }
    }
}
