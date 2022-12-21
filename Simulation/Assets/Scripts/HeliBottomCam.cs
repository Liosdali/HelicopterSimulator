using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBottomCam : MonoBehaviour
{

    [SerializeField]
    private MeshRenderer m_MeshRenderer;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
