using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MissionType
{
    empty,
    Fire,
    Hook
}

public class HookMissionHandler : MonoBehaviour
{
    
    [SerializeField]
    private MissionType missionType;

    [SerializeField]
    private float m_waterPercentage;

    [SerializeField]
    private float m_flowRate;


    [SerializeField]
    private bool m_hookEnabled;


    Mission mission;
    FireMission fire;

    public void EnableHook()
    {
        m_hookEnabled = true;
    }

    public void DisableHook()
    {
        m_hookEnabled = false;
    }

    public void HookChange()
    {
        m_hookEnabled = !m_hookEnabled;
    }

    private void OnTriggerStay(Collider other)
    {
        // Works with inheritance
        if ( other.gameObject.TryGetComponent<Mission>(out Mission component))
        {
            mission = component;

            switch (mission.type)
            {
                default:
                    Debug.Log("No mission Is Present");
                    break;
                case MissionType.Fire:
                    if (m_waterPercentage < 0)
                    {
                        //trigger = true;
                        if (m_waterPercentage > 0)
                        {
                            m_waterPercentage -= m_waterPercentage * Time.deltaTime * m_flowRate;
                            fire = other.GetComponent<FireMission>();
                            fire.reduceHp();
                        }
                        
                    }
                    break;

                
            }
        }
        else if (other.tag == "Water")  // Other gameobject layer 
        {
            Debug.Log(other);
            if (m_hookEnabled)
            {
                if (m_waterPercentage < 100f)
                {
                    //m_waterPercentage += m_waterPercentage * Time.deltaTime * m_flowRate;
                    m_waterPercentage += Time.deltaTime * m_flowRate;
                    //Debug.Log(waterPercentage);
                }
                other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
            }

        }

    }
}
