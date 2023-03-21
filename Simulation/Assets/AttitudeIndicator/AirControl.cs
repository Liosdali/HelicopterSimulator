using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oyedoyin.Common;

public class AirControl : MonoBehaviour
{
	public Transform CameraRigPivot;

    private float m_Yaw;
    private float m_RollInput;
    private float m_PitchInput;

	const float YawRate = 30.0f;
	const float PitchRate = 30.0f;
	const float RollRate = 45.0f;


    public static AirControl Instance;

    private void Start()
    {
        Instance = this;
    }

    public void SetInputs(float roll, float pitch)
    {
        m_RollInput = roll;
        m_PitchInput = pitch;
    }


    void LateUpdate ()
	{
        //Yaw += Input.GetAxis( "Horizontal") * Time.deltaTime * YawRate;
        //Pitch += Input.GetAxis( "Vertical") * Time.deltaTime * PitchRate;
        //if (Input.GetKey( KeyCode.Alpha1)) Roll += Time.deltaTime * RollRate;
        //if (Input.GetKey( KeyCode.Alpha2)) Roll -= Time.deltaTime * RollRate;

        //Implementing 


        m_PitchInput += m_PitchInput * Time.deltaTime * PitchRate;

		CameraRigPivot.rotation = Quaternion.Euler( m_PitchInput, m_Yaw, -m_RollInput);

		// return to normal pitch and roll to avoid gimbal lock

        // Gimbal lock preventation
		m_PitchInput -= m_PitchInput * Time.deltaTime;
		m_RollInput -= m_RollInput * Time.deltaTime;

	}
}
