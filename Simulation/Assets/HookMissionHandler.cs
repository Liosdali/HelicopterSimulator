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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Works with inheritance
        if ( other.gameObject.TryGetComponent<Mission>(out Mission component))
        {
            Mission mission = component;

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
                            
                        }
                        FireMission fire = other.GetComponent<FireMission>();
                        fire.reduceHp();
                    }
                    break;

                
            }
        }
        else if (other.tag == "Water")
        {
            Debug.Log(other);
            //if (hook_enabled)
            //{
            //    if (waterPercentage < 100f)
            //    {
            //        //waterPercentage += waterPercentage * Time.deltaTime * flowRate;
            //        //Debug.Log(waterPercentage);
            //    }
            //    other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
            //}
            
        }

    }
}
