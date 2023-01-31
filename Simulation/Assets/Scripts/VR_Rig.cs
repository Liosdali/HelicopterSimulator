using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VR_Map
{
    // Should convert it to private with serializefields

    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackPositionOffset;
    public Vector3 trackRotationOffset;



    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackPositionOffset);

        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackRotationOffset);
    }

}


public class VR_Rig : MonoBehaviour
{

    public VR_Map m_Head;
    public VR_Map m_LeftHand;
    public VR_Map m_RightHand;


    [SerializeField]
    private Transform m_HeadConstraint;


    [SerializeField]
    private Vector3 m_HeadBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        m_HeadBodyOffset = transform.position - m_HeadConstraint.position;   
    }

    private void LateUpdate()
    {

        transform.position = m_HeadConstraint.position + m_HeadBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(m_HeadConstraint.up, Vector3.up).normalized;

        m_Head.Map();
        m_LeftHand.Map();
        m_RightHand.Map();
    }
}
