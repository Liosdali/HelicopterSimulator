using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
   
    // To-do
    // -handling required stuff explained in function comments

    [SerializeField]
    private List<Mission> m_Missions = new List<Mission>();

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
    
    void RemoveSpecifiedMission(Mission mission)
    {
        if (m_Missions.Count < 0)
            m_Missions.Remove(mission);
        else
            Debug.Log("Mission Over");
    }

}
