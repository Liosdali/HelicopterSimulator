using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;

public class AltituteIndıcator : MonoBehaviour
{

    [SerializeField]
    private Transform helicopter;
    public Transform objectToLookAt;

    public static AltituteIndıcator instance;

    private float m_rollInput;
    private float m_pitchInput;


    private void Start()
    {
        instance = this;
    }

    public void SetInputs(float roll, float pitch)
    {
        m_rollInput = roll;
        m_pitchInput = pitch;
    }


    void Update()
    {
        float degreesPerSecond = 90 * Time.deltaTime;
        Vector3 direction = objectToLookAt.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
        
        //transform.rotation.x       
       

    }
   

    void Test()
    {
        transform.LookAt(helicopter.transform);
    }
}
 