using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLines : MonoBehaviour
{


    [SerializeField]
    private Transform m_PositionOne;
    [SerializeField]
    private Transform m_PositionTwo;

    [SerializeField]
    private List<Transform> m_TutorialTransforms;



    private LineRenderer m_LineRenderer;

    [SerializeField]
    private bool m_fixPoint = false;


    // Start is called before the first frame update
    void Start()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_fixPoint) { FixPoints(); }

    }


    private void FixPoints()
    {
        m_LineRenderer.SetPosition(0, m_PositionOne.position);
        m_LineRenderer.SetPosition(1, m_PositionTwo.position);
    }


    public void UpdateSecPos()
    {
        if (m_TutorialTransforms.Count > 0)
        {
            m_PositionTwo = m_TutorialTransforms[0];
            m_TutorialTransforms.RemoveAt(0);
        }
    }

}
