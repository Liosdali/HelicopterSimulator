using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class HSpotLight : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObject;


    private bool isActive = false;
   public void LightOpenClose()
    {
        isActive = gameObject.activeSelf;
        if (isActive) { gameObject.SetActive(false); }
        else { gameObject.SetActive(true); }    

    }
}
