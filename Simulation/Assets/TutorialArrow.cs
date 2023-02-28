using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{



    public Transform[] missionTransforms;

    public static TutorialArrow instance;

    private int m_counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (missionTransforms == null)
            Destroy(gameObject);
    }

    void DestroyAllObjects()
    {
        Debug.Log("Destroying tutorial objects");
        foreach (Transform transform in missionTransforms)
        {
            Destroy(transform.gameObject);
        }
    }


    public void GoToNextObjective(int objectNumber)
    {
        if (missionTransforms.Length == m_counter )
        {
            Debug.Log("Tutorial has finished");
            //Destroy(gameObject);
            return;
        }

        if (missionTransforms.Length != objectNumber)
            return;

        //missionTransforms[m_counter].gameObject.SetActive(true);
        m_counter++;
        gameObject.transform.position = missionTransforms[m_counter].transform.position;
    }

}
