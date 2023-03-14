using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;

public class AltituteIndicator : MonoBehaviour
{



    public static AltituteIndicator instance;

    //public Controller m_silantroController;

    private float feet;

    private float m_rollInput;
    private float m_pitchInput;

    [SerializeField]
    private float m_degreesPerSecond = 45f;

    private void Start()
    {
        instance = this;
    }

    public void SetInputs(float roll, float pitch)
    {
        m_rollInput = roll;
        m_pitchInput = pitch;
    }

    public void SetFeet(float feet)
    {
        this.feet = feet;
    }

    // X altitute
    // Y left right tilt
    // Z horizontal rotation 
    void LateUpdate()
    {



        // 
        //float Altitude = (float)(m_silantroController.m_core.z * Oyedoyin.Mathematics.Constants.m2ft);
        //FEEET
        
        Debug.Log("Altitude check = " + feet + "ft");
        Vector3 ballRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + m_pitchInput);
        
        Quaternion targetRotation = Quaternion.LookRotation(ballRotation); 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_degreesPerSecond);

    }
   
}
 