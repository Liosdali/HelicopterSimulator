using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;
public class HeliBottomCam : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer m_MeshRenderer;

    private bool active = false;

    public static HeliBottomCam instance;

    private void Start()
    {
        instance = this;
        DisableOrActivateRenderer();
    }

    //public float _alti;

    public void DisableOrActivateRenderer()
    {
        if (active) 
            m_MeshRenderer.enabled = false;
        else
            m_MeshRenderer.enabled = true;

        active = !active;
    }

}
