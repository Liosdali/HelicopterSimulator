using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltituteIndıcator : MonoBehaviour
{

    [SerializeField]
    private Transform helicopter;
    public Transform objectToLookAt;


    void Update()
    {
        float degreesPerSecond = 90 * Time.deltaTime;
        Vector3 direction = objectToLookAt.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
    }
   

    void Test()
    {
        transform.LookAt(helicopter.transform);
    }
}
 