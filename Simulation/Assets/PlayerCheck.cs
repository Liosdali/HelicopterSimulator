using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCheck : MonoBehaviour
{


    [SerializeField] private Transform _player;
    [SerializeField]
    private Vector3 m_PlayerResetPos = Vector3.zero;
    // Vector3(0.327526718,-0.777336061,0.257475019)
    // Update is called once per frame



    private float _checkY = 0.300f;
    private static bool m_PlayerUpdate = false;

    public static void FlipUpdate()
    {
        m_PlayerUpdate = !m_PlayerUpdate;
    }


    void Update()
    {
        if (m_PlayerUpdate)
        {

            // Checking if the device connected 

            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevices(inputDevices);
            Debug.Log(inputDevices.Count);

            if (inputDevices.Count > 0)
            {
                Debug.LogError("XR device present");
                if (DeviceOn())
                    ResetPosition();
                else
                    Debug.LogError("Device is not mounted");
            }
            else
            {
                Debug.LogError("No XR devices Present ");
            }


        }
    }

    void ResetPosition()
    {
        
            if (_player.transform.position.y > _checkY)
                PlayerCamTeleport.instance.ResetPosition();
            Destroy(gameObject); // Free memory
    }


    public static bool DeviceOn()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }
}
