using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCheck : MonoBehaviour
{

    [SerializeField] private Transform _player;
    
    private float _checkY = 0.300f;
    private static bool m_PlayerUpdate = false;


    private static InputDevice headDevice;
    private void Start()
    {
        if (headDevice == null)
        {
            headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }
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
                if (IsHMDMounted() )
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

    public static void FlipUpdate()
    {
        m_PlayerUpdate = !m_PlayerUpdate;
    }


    void ResetPosition()
    {
        
            if (_player.transform.position.y > _checkY)
                PlayerCamTeleport.instance.ResetPosition();
            Destroy(gameObject); // Free memory
    }


    
    /// <summary>
    /// returns true if the HMD is mounted on the users head. Returns false if the current headset does not support this feature or if the HMD is not mounted.
    /// </summary>
    /// <returns></returns>
    public static bool IsHMDMounted()
    {
        if (headDevice == null || headDevice.isValid == false)
        {
            headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }
        if (headDevice != null)
        {
            bool presenceFeatureSupported = headDevice.TryGetFeatureValue(CommonUsages.userPresence, out bool userPresent);
            if (headDevice.isValid && presenceFeatureSupported)
            {
                return userPresent;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    /// HMD Works
}
