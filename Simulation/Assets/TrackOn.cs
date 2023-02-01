using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class TrackOn : MonoBehaviour
{
 
    private  TrackedPoseDriver _TrackedPoseDriver;

    public static TrackOn Instance;


    private void Awake()
    {
        _TrackedPoseDriver = GetComponent<TrackedPoseDriver>();
        Instance = this;
    }

    public void EnableTracking()
    {
        _TrackedPoseDriver.enabled = true;
    }
    public void DisableTracking()
    {
        _TrackedPoseDriver.enabled = false;
    }

}
