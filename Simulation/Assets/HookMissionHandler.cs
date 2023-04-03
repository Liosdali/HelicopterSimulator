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
                case MissionType.Fire:

                    break;

                default:

                    break;
            }
        }
    }
}
