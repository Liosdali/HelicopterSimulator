using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;

public class AltitudeIndicator : MonoBehaviour
{



    public static AltitudeIndicator instance;

    //public Controller m_silantroController;

    private float feet;

    private float m_rollInput;
    private float m_pitchInput;
    private float m_XRotationChange;
    private float m_TargetXRotation;
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

        AltitudeChange();
        RotationChange();

        // 
        //float Altitude = (float)(m_silantroController.m_core.z * Oyedoyin.Mathematics.Constants.m2ft);
        //FEEET
        
        Debug.Log("Altitude check = " + feet + "ft");





        Vector3 ballRotation = new Vector3(m_TargetXRotation, 0, 0);
        
        Quaternion targetRotation = Quaternion.LookRotation(ballRotation); 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_degreesPerSecond);


          // Need an implementation of a function to prevent gimbal lock 
        // ----------------------------------------------------------- //

    }
   


    // FEET 800 TOPS
    // 800 / 80

    // +45  -45
    //90/ 10 => 10 
    void AltitudeChange()
    {
        m_XRotationChange = feet / 80f;
        m_XRotationChange *= 4.5f;

        if (transform.rotation.x != m_XRotationChange)
        {
            m_TargetXRotation = m_XRotationChange;

        }
        else
        {
            m_TargetXRotation = transform.rotation.x;
        }
    }

    void RotationChange()
    {

    }

}
 