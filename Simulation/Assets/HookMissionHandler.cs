using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Slider m_waterSlider;

    [SerializeField]
    private Text m_waterText;


    Mission mission;
    FireMission fire;


    private void Start()
    {
        m_waterSlider.value = m_waterPercentage;
        m_waterText.text = "% " + ((int)m_waterPercentage).ToString();
    }

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

    // Sepetin calismasini saglayan kod blogu
    // Collision tabanli bir bicimde calisiyor
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        
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
                    missionType = MissionType.Fire;
                    if (m_waterPercentage > 0)
                    {
                        //trigger = true;
                        if (m_hookEnabled)
                        {
                            fire = other.GetComponent<FireMission>();
                            if (!fire._isExt)
                            {
                                m_waterPercentage -= Time.deltaTime * m_flowRate;
                                m_waterSlider.value = m_waterPercentage * 0.01f;
                                m_waterText.text = "% " + ((int)m_waterPercentage).ToString();
                                fire.reduceHp();

                                Debug.Log("Extinguishing");
                            }
                        }
                        
                    }
                    break;

                
            }
        }
        else if (other.tag == "Water")  // Other gameobject layer 
        {
            
            if (m_hookEnabled)
            {
                if (m_waterPercentage < 100f)
                {
                    //m_waterPercentage += m_waterPercentage * Time.deltaTime * m_flowRate;
                    m_waterPercentage += Time.deltaTime * m_flowRate;
                    m_waterSlider.value = m_waterPercentage * 0.01f;

                    m_waterText.text = "% " + ((int)m_waterPercentage).ToString();


                    
                    //Debug.Log(waterPercentage);
                }
                //other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
            }

        }

    }
}
