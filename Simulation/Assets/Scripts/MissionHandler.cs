using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    // To-do
    // -handling required stuff explained in function comments

    [SerializeField]
    private List<Mission> m_Missions = new List<Mission>();


    [SerializeField]
    private MissionPanel[] m_Panels;

    [SerializeField]
    private GameObject m_MissionArrow;

    public static MissionHandler Instance;

    private void Start()
    {
        m_MissionArrow.transform.position = m_Missions[0].gameObject.GetComponentInChildren<Transform>().position;
        Instance = this;

        m_Panels = FindObjectsOfType<MissionPanel>();

        foreach (var panel in m_Panels)
        {
            panel.MissionCount = m_Missions.Count;
            panel.InitText();
        }
    }

    // Removing mission from the list
    public void NextMission()
    {
        if (RemoveMission())
        {
            foreach (var panel in m_Panels)
            {
                panel.UpdateText();
            }
            m_MissionArrow.transform.position = m_Missions[0].gameObject.GetComponentInChildren<Transform>().position;
        }
        else
        {
            m_MissionArrow.gameObject.SetActive(false);
            foreach (var panel in m_Panels)
            {
                panel.UpdateText();
            }
            Debug.Log("Missions finished");
        }

    }

    // Handling mission events and progressing further 
    bool RemoveMission()
    {
        if (m_Missions.Count > 0)
        {
            // Handle missions objects that are going to be changed
            //m_Missions[0].gameObject.SetActive(false);
            m_Missions.RemoveAt(0);

        }
        else
            Debug.Log("Mission Over");

        if (m_Missions.Count == 0)
            return false;
        return true;
    }
    
    void RemoveSpecificMission(Mission mission)
    {
        if (m_Missions.Count < 0)
            m_Missions.Remove(mission);
        else
            Debug.Log("Mission Over");
    }

}
