using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{ 

    [SerializeField]
    private Transform m_SourceTransform;

    [SerializeField]
    private Transform m_TargetTransform;



    public float m_LookRange;

    private bool m_Check = true;
    private bool m_Start = false;


    private void Start()
    {
        // Checking null objects
        if (m_SourceTransform == null || m_TargetTransform == null)
        {
            m_Check = false;
        }
    }



    private void Update()
    {
        //if (m_Start)
        //{
            
            if (Vector3.Distance(m_SourceTransform.position, m_TargetTransform.position) < m_LookRange)
            {
                Debug.Log("Start Looking");
                m_SourceTransform.LookAt(m_TargetTransform);
            }
        //}
    }

    // Update is called once per frame
    public void LookAt()
    {
        m_SourceTransform.LookAt(m_TargetTransform);      
    }



    /*
    public void LookAt()
    {
        if (m_Check)
        {
            //if ((m_SourceTransform.position - m_TargetTransform.position).magnitude < m_LookRange)
            if (Vector3.Distance(m_SourceTransform.position, m_TargetTransform.position) < m_LookRange)
                m_SourceTransform.LookAt(m_TargetTransform);
        }
    }
    */


}
