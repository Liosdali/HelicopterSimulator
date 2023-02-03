using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private Transform pilotSeat;
    [SerializeField] private GameObject pilot;
    [SerializeField] private GameObject locomotionSystem;

    [SerializeField] private GameObject m_PilotOutsideModel;
    [SerializeField] private GameObject m_PilotInsideModel;
    [SerializeField] private GameObject m_UICanvas;


    private float waitSeconds = 3.0f;
    private bool teleport = false;
    private bool m_AnimationPlay = false;


    public void teleportPlayer()
    {
        pilot.transform.position = pilotSeat.position;
        //pilot.transform.localPosition = pilotSeat.localPosition;
        //pilot.transform.localPosition = pilotSeat.localPosition;
        pilot.transform.rotation = pilotSeat.rotation;
        m_PilotOutsideModel.SetActive(false);
        //Destroy(m_PilotOutsideModel);
        //
        m_PilotInsideModel.SetActive(true);
        //m_UICanvas.SetActive(true);
        teleport = false;
    }

    private void Update()
    {
        if (teleport)
        {
            if (waitSeconds <= 0)
            {
                teleportPlayer();
                teleport = false;
                waitSeconds = 2.0f;
                GetComponent<AnimationTrigger>().enabled = false;
            }
            else
                waitSeconds -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerHand"))
        {
            teleport = true;
            if (!m_AnimationPlay)
            {
                m_AnimationPlay = true;
                myDoor.SetTrigger("Open");
            }
            Destroy(locomotionSystem.GetComponent<DeviceBasedContinuousMoveProvider>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            //teleport = false;
            //myDoor.SetTrigger("Close");
            GetComponent<BoxCollider>().enabled = false;
            // Destroying object to free some memory space
            //Destroy(gameObject);
        }

    }

}
