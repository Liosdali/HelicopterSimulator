using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltituteIndıcator : MonoBehaviour
{

    [SerializeField]
    private Transform helicopter;


    // x * -1
    // y directly

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = new Quaternion(helicopter.rotation.x, helicopter.rotation.y, 0, 0);

        //Vector3 eulerRotation = new Vector3(-helicopter.rotation.x, helicopter.rotation.y, helicopter.rotation.z);
        //transform.rotation = Quaternion.Euler(eulerRotation);



        Test();
    }

    void Test()
    {
        transform.LookAt(helicopter.transform);
    }
}
