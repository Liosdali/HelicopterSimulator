 using UnityEngine;
#if (ENABLE_INPUT_SYSTEM)
using UnityEngine.InputSystem;
#endif

#if VR_ACTIVE
using UnityEngine.XR.Interaction.Toolkit;
#endif


/// <summary>
/// 
/// </summary>
namespace Oyedoyin.Common
{
    public class SilantroHand : MonoBehaviour
    {
        public enum HandType { Right, Left }

        [Header("Connections")]
#if VR_ACTIVE
    public XRController m_controller;
    public InputHelpers.Button m_gripButton;
    public InputHelpers.Button m_triggerButton;
    public InputHelpers.Button m_thumbButton;
#endif
        public HandType m_handType = HandType.Right;
        public Animator m_animator;


        public Animator _PilotAnimator = null;
        public Animator _PilotSnapAnimator = null;


        [Header("Animator Keys")]
        public string m_gripName = "Grip";
        public string m_triggerName = "Trigger";

        [Header("Data")]
        public float m_speed = 10;
        [HideInInspector] public float gripValue;
        [HideInInspector] public float triggerValue;

        private float m_currentTrigger;
        private float m_currentGrip;

        /// <summary>
        /// 
        /// </summary>
        /// 

        public LeverAnimType m_animatorType;


        private string _GripName;
        private float _GripValue;

        private string _TriggerName;
        private float _TriggerValue;

        private bool _AnimEnabled;

        public void SetAnimBool(bool anim)
        {
            _AnimEnabled = anim;
        }


        private void Start()
        {
            if (m_handType == HandType.Right)
            {
                _GripName = "Grip_Right";
                _TriggerName = "Trigger_Right";
                return;
            }

            _GripName = "Grip_Left";
            _TriggerName = "Trigger_Left";
        }
        protected void Update()
        {

        #if VR_ACTIVE
            if (m_controller != null)
            {
                m_controller.inputDevice.TryReadSingleValue(m_gripButton, out gripValue);
                m_controller.inputDevice.TryReadSingleValue(m_triggerButton, out triggerValue);
            } 
        #endif

            if (m_animator != null)
            {
                if (!_AnimEnabled)
                {
                    _PilotSnapAnimator.gameObject.SetActive(false);
                    _PilotAnimator.gameObject.SetActive(true);
                    GripValues();
                    TriggerValues();
                }
                else
                {

                    _PilotSnapAnimator.gameObject.SetActive(true);
                    _PilotAnimator.gameObject.SetActive(false);

                    switch (m_animatorType)
                    {
                        case LeverAnimType.Lever:
                            _PilotSnapAnimator.SetTrigger("");
                            break;
                        case LeverAnimType.ControlStick:
                            _PilotSnapAnimator.SetTrigger("");
                            break;

                        default:
                            Debug.Log("Hand Anim Fail");
                            break;
                    }
                }
            }
        }




        private void GripValues()
        {
            //-------------------------------------------- Grip
            if (m_currentGrip != gripValue)
            {
                m_currentGrip = Mathf.MoveTowards(m_currentGrip,
                    gripValue, Time.deltaTime * m_speed);

                _GripValue = Mathf.MoveTowards(_GripValue,
                    gripValue, Time.deltaTime * m_speed);


                m_animator.SetFloat(m_gripName, m_currentGrip);
                _PilotAnimator.SetFloat(_GripName, m_currentGrip);


                //if (_PilotAnimator != null)
                //{
                //    _PilotAnimator.SetFloat(_GripName, m_currentGrip);
                //}

                //if (_PilotInsideAnimator != null)
                //{
                //    _PilotInsideAnimator.SetFloat(_GripName, m_currentGrip);
                //}
            }
        }


        private void TriggerValues()
        {
            //-------------------------------------------- Trigger
            if (m_currentTrigger != triggerValue)
            {
                // Setting trigger value for the hand  
                m_currentTrigger = Mathf.MoveTowards(m_currentTrigger, triggerValue, Time.deltaTime * m_speed);
                _TriggerValue = Mathf.MoveTowards(_TriggerValue, triggerValue, Time.deltaTime * m_speed);

                m_animator.SetFloat(m_triggerName, m_currentTrigger);
                _PilotAnimator.SetFloat(_TriggerName, m_currentTrigger);

                //if (_PilotAnimator != null)
                //{
                //    _PilotAnimator.SetFloat(_TriggerName, m_currentTrigger);
                //}
                //if (_PilotInsideAnimator != null)
                //{                       
                //    _PilotInsideAnimator.SetFloat(_TriggerName, m_currentTrigger);
                //}
            }
        }
    }
}
