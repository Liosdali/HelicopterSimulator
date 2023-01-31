using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField] private Transform _targetTransform;
    [SerializeField] private GameObject _pilot;
    [SerializeField] private GameObject locomotionSystem;
    [SerializeField] private bool _locomotiveStatus;

    public static TeleportPlayer Instance;


    private void Awake()
    {
        Instance = this;
    }



    public void teleportPlayer()
    {
        locomotionSystem.SetActive(_locomotiveStatus);
        _pilot.transform.position = _targetTransform.position;
        _pilot.transform.rotation = _targetTransform.rotation;
        //FadeScript.instance.FadeIn();
    }
}
