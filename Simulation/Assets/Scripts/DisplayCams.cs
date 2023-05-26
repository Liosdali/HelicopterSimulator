using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;

public class DisplayCams : MonoBehaviour
{

    [SerializeField]
    private Camera[] cameras;

    private GameObject m_attributeCanvas;

    private int count = 0;

    // Needing a both eye renderer 
    // without doing much work

    // Start is called before the first frame update
    void Start()
    {
        m_attributeCanvas = GetComponentInChildren<SilantroMisc>().gameObject;
        m_attributeCanvas.GetComponent<Canvas>().worldCamera = cameras[0];
       //foreach(Camera cam in cameras)
       // {
       //     cam.gameObject.SetActive(false);

       // } 

       for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
            cameras[i].enabled = false;
        }

       cameras[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Dont forget to remove the VR main camera from here !!!
        if (Input.GetButtonDown("Jump"))
        {
            if (count != 0)
            {
                cameras[count].gameObject.SetActive(false); // If the object is not vr camera then disable
                cameras[count].enabled = false;
            }
            count++;
            if (count == cameras.Length)
                count = 0;
            cameras[count].gameObject.SetActive(true);
            cameras[count].enabled = true;
            m_attributeCanvas.GetComponent<Canvas>().worldCamera = cameras[count];
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            m_attributeCanvas.SetActive(!m_attributeCanvas.activeSelf);
        }
    }
}
