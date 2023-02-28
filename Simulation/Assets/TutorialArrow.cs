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

        gameObject.transform.position = missionTransforms[m_counter].transform.position;

    }

    void DestroyAllObjects()
    {
        Debug.Log("Destroying tutorial objects");
        foreach (Transform transform in missionTransforms)
        {
            Destroy(transform.gameObject);
        }
    }


    // Starts with 0 


    public void GoToNextObjective(int objectNumber)
    {
        if (missionTransforms.Length == m_counter )
        {
            Debug.Log("Tutorial has finished");
            return;
        }

        if (m_counter != objectNumber)
            return;

        //missionTransforms[m_counter].gameObject.SetActive(true);
        m_counter++;
        gameObject.transform.position = missionTransforms[m_counter].transform.position;
    }

}
