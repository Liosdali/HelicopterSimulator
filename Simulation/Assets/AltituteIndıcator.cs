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
        transform.rotation = new Quaternion(helicopter.rotation.x * -1 , helicopter.rotation.y, 0, 0);
    }
}
