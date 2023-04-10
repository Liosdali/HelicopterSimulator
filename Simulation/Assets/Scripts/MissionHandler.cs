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


    public void NextMission()
    {
        // Check if the mission list is not empty also
        // remove the current mission from the list
        if (RemoveMission())
        {
            //Mission handler -> next mission -> open necessary stuff 
            // Mission event complete -> Remove Mission ( Function Handles Necessary stuff)
            // Things like box collider, activating or deactivating objects
            //
            m_MissionArrow.transform.position = m_Missions[0].gameObject.GetComponentInChildren<Transform>().position;
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
