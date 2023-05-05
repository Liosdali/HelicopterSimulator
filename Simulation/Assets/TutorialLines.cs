using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLines : MonoBehaviour
{


    [SerializeField]
    private Transform m_PositionOne;
    [SerializeField]
    private Transform m_PositionTwo;


    private LineRenderer m_LineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
