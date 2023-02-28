using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{



    public Transform[] missionTransforms;


    private int m_counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (missionTransforms == null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GoToNextObjective()
    {
        if (missionTransforms.Length - 1 == m_counter )
        {
            Debug.Log("Tutorial has finished");
            Destroy(gameObject);
            return;
        }

        //missionTransforms[m_counter].gameObject.SetActive(true);
        m_counter++;


    }

}
