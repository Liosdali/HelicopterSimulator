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
    private GameObject m_MissionArrow;

    public static MissionHandler Instance;

    private void Start()
    {
        m_MissionArrow.transform.position = m_Missions[0].gameObject.GetComponentInChildren<Transform>().position;
        Instance = this;
    }

    // Removing mission from the list
    public void NextMission()
    {
        if (RemoveMission())
        {
            m_MissionArrow.transform.position = m_Missions[0].gameObject.GetComponentInChildren<Transform>().position;
        }
        else
        {
            Debug.Log("");
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
