using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;
public class HeliBottomCam : MonoBehaviour
{
    // Bottom cam can be upgraded
    // To allow the usage of control equipment

    [SerializeField]
    private MeshRenderer m_MeshRenderer;

    private bool active = false;

    public static HeliBottomCam instance;

    private void Start()
    {
        instance = this;
        //DisableOrActivateRenderer();
    }



    private void Update()
    {
        if ( altitude > 30f)
        {
            EnableCam();
        }
        else
        {
            DisableCam();
        }
    }

    //public float _alti;

    public float altitude = 0f;

    private void EnableCam()
    {
        m_MeshRenderer.enabled = true;
        active = true;
    }
    private void DisableCam()
    {
        m_MeshRenderer.enabled = false;
        active = false;
    }

    public void DisableOrActivateRenderer()
    {
        if (active) 
            m_MeshRenderer.enabled = false;
        else
            m_MeshRenderer.enabled = true;

        active = !active;
    }

}
