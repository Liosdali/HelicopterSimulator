using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{

    // Create the cutscene here or timeline
    // Cutscene will show the fire 

    [SerializeField]
    private GameObject m_playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // This Function will be called after the end of the cutscene
    void FinishCutscene()
    {
        gameObject.SetActive(false);
        m_playerCam.SetActive(true);
        FadeScript.instance.ChangeFadeStart();
        Destroy(gameObject);
    }


}
