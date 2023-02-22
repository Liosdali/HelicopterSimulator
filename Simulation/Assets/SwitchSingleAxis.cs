using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oyedoyin.Common;


[RequireComponent(typeof(Rigidbody))]
public class SwitchSingleAxis : MonoBehaviour
{

    public enum RotationAxis { X, Y }

    public RotationAxis leverAxis = RotationAxis.X;


    // Connections
    public Transform m_hinge;
    [SerializeField]
    private SilantroHand m_controller;

    // Properties
    public bool leverHeld;
    public float snapSpeed = 10f;
    public float maximumDeflection = 20f;
    public float maximumPitchDeflection = 20f, maximumRollDeflection = 20f;
    public float maximumMovement = 5;

    private Vector3 m_baseLeverPosition;
    private Quaternion m_baseLeverRotation;

    // Output
    public float leverOutput;
    public float pitchOutput, rollOutput;
    private Vector2 angle, value;
    private Vector2 deflectionLimit = new Vector2(30, 30);
    private Vector3 handPosition;
    private Vector3 localHandPosition;
    Vector3 m_yokeAxisRoll;


    public GameObject m_Hand;
    public GameObject m_LeftHand = null;
    public GameObject m_RightHand = null;

    private Transform _referenceTransform = null;


    public void Initialize()
    {
        if (m_Hand != null)
        {
            m_Hand.SetActive(false);
        }

        if (leverAxis == RotationAxis.X) { deflectionLimit = new Vector2(maximumDeflection / 2, 0); }
        if (leverAxis == RotationAxis.Y) { deflectionLimit = new Vector2(0, maximumDeflection / 2); }


        if (m_hinge != null)
        {
            m_baseLeverPosition = transform.parent.InverseTransformPoint(m_hinge.position);
            m_baseLeverRotation = m_hinge.localRotation;
        }
    }

    public bool keyTest = false;


    private void Start()
    {
        if (keyTest)
        {
            Initialize();
        }
    }

    private void Update()
    {
        if (keyTest)
        {
            Compute();
        }

        if (leverHeld)
        {
            handPosition = _referenceTransform.position;
        }

        if (m_controller != null)
        {
            if (m_controller.gripValue < 0.9f)   //if (m_controller.triggerValue < 0.9f && m_controller.gripValue < 0.9f)
            {
                Debug.Log("Lever =" + gameObject.name + " ref = " + m_controller.gameObject.name);
                m_controller.SetAnimBool(false);
                if (m_Hand != null)
                    m_Hand.SetActive(false);
                leverHeld = false;
                m_controller._isBeingUsed = false;
                m_controller = null;

            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (m_controller == null)
            {

                if (!other.GetComponent<SilantroHand>()._isBeingUsed)
                {
                    m_controller = other.GetComponent<SilantroHand>();
                    m_controller._isBeingUsed = true;
                }
                else
                    return;
            }

            if (m_controller != null)
            {
                if (m_controller.gripValue > 0.9f)   //if (m_controller.triggerValue > 0.9f && m_controller.gripValue > 0.9f)
                {
                    leverHeld = true;
                    m_controller.SetAnimBool(true);

                    if (m_LeftHand != null && m_RightHand != null)
                    {
                        if (m_controller.m_handType == SilantroHand.HandType.Left)
                        {
                            m_Hand = m_LeftHand;
                        }
                        else
                        {
                            m_Hand = m_RightHand;
                        }
                    }
                    m_Hand.SetActive(true);
                }
                else
                {
                    m_controller.SetAnimBool(false);
                    leverHeld = false;


                    if (m_Hand != null)
                        m_Hand.SetActive(false);
                }
            }

            //Hand Data
            if (leverHeld)
            {
                //handPosition = other.transform.position;
                _referenceTransform = other.transform;
                handPosition = _referenceTransform.position;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (m_controller != null && m_controller.gripValue < 0.9f) // && leverHeld)   //if (m_controller.triggerValue > 0.9f && m_controller.gripValue > 0.9f)
            {
                leverHeld = false;
                m_controller.SetAnimBool(false);
                m_Hand.SetActive(false);
                m_controller = null;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void AnalyseLeverState()
    {
        localHandPosition = transform.InverseTransformPoint(handPosition);

        if (leverHeld)
        {
                angle.x = Vector2.SignedAngle(new Vector2(localHandPosition.y, localHandPosition.z), Vector2.up);
                angle.y = Vector2.SignedAngle(new Vector2(localHandPosition.x, localHandPosition.z), Vector2.up);
                angle = new Vector2(Mathf.Clamp(angle.x, -deflectionLimit.x, deflectionLimit.x), Mathf.Clamp(angle.y, -deflectionLimit.y, deflectionLimit.y));
                value = new Vector2(angle.x / (deflectionLimit.x + Mathf.Epsilon), angle.y / (deflectionLimit.y + Mathf.Epsilon));
                m_hinge.localRotation = Quaternion.LookRotation(Vector3.SlerpUnclamped(Vector3.SlerpUnclamped(new Vector3(-1, -1, 1),
                    new Vector3(-1, 1, 1), value.x * deflectionLimit.x / 90 + .5f), Vector3.SlerpUnclamped(new Vector3(1, -1, 1),
                    new Vector3(1, 1, 1), value.x * deflectionLimit.x / 90 + .5f), value.y * deflectionLimit.y / 90 + .5f), Vector3.up);

          
        }


        ////Reset Core
        //if (leverAction == LeverAction.SelfCentering && !leverHeld)
        //{
        //    if (m_mode == LeverMode.RotateOnly)
        //    {
        //        value = Vector2.MoveTowards(value, Vector2.zero, Time.deltaTime * snapSpeed);
        //        m_hinge.localRotation = Quaternion.LookRotation(Vector3.SlerpUnclamped(Vector3.SlerpUnclamped(
        //            new Vector3(-1, -1, 1), new Vector3(-1, 1, 1), value.x * deflectionLimit.x / 90 + .5f),
        //            Vector3.SlerpUnclamped(new Vector3(1, -1, 1), new Vector3(1, 1, 1), value.x * deflectionLimit.x / 90 + .5f),
        //            value.y * deflectionLimit.y / 90 + .5f), Vector3.up);
        //    }
         
        //}

        if (m_controller != null && m_controller.triggerValue < 0.9f && m_controller.gripValue < 0.9f && leverHeld) { leverHeld = false; }
    }

    private void AnalyseLeverInput()
    {
        //leverAxisState == AxisState.Inverted ? 1 - ((-value.x + 1) / 2) :
        //leverAxisState == AxisState.Inverted ? 1 - ((-value.y + 1) / 2) :
        if (leverAxis == RotationAxis.X) 
        { 
            leverOutput = (-value.x + 1) / 2; 
        }
        if (leverAxis == RotationAxis.Y) 
        { 
            leverOutput = (-value.y + 1) / 2; 
        }

    }

    public void Compute()
    {
        AnalyseLeverState();
        AnalyseLeverInput();
    }
}
