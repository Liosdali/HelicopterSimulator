using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCheck : MonoBehaviour
{


    [SerializeField] private Transform _player;
    [SerializeField]
    private Vector3 m_PlayerResetPos = Vector3.zero;
    // Vector3(0.25,0.336600006,0.411000013);
    // Update is called once per frame



    private float _checkY = 0.650f;
    private static bool m_PlayerUpdate = false;

    public static void FlipUpdate()
    {
        m_PlayerUpdate = !m_PlayerUpdate;
    }


    void Update()
    {
        if (m_PlayerUpdate)
        {
            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevices(inputDevices);
            Debug.Log(inputDevices.Count);

            if (inputDevices.Count > 0)
            {
                Debug.LogError("XR device present");
                //ResetPosition();
            }
            else
            {
                Debug.LogError("No XR devices Present ");
            }


        }
    }



    void ResetPosition()
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);
        Debug.Log(inputDevices.Count);
        
        
        if (inputDevices.Count > 0)
        {
            if (_player.transform.position.y > _checkY)
                PlayerCamTeleport.instance.ResetPosition();
            Destroy(gameObject); // Free memory
        }
    }
}
