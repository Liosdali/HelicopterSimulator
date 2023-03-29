using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCams : MonoBehaviour
{

    [SerializeField]
    private Camera[] cameras;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       foreach(Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        } 
       cameras[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            cameras[count].gameObject.SetActive(false);
            count++;
            if (count == cameras.Length)
                count = 0;
            cameras[count].gameObject.SetActive(true);
        }
    }
}
