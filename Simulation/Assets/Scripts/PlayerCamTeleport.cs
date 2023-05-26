using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamTeleport : MonoBehaviour
{
    [SerializeField] private Transform m_resetTransform;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Camera m_playerCam;

    public static PlayerCamTeleport instance;

    private bool m_isTeleporting = false;


    // PlayerCamTeleport
    public Transform GetResPosition()
    {
        return m_resetTransform;
    }

    private void Start()
    {
        instance = this;
    }

    [ContextMenu("Reset Position")]
    public void ResetPosition()
    {
        float rotationAngleY = m_resetTransform.rotation.eulerAngles.y 
            - m_playerCam.transform.rotation.eulerAngles.y;

        m_player.transform.Rotate(0, rotationAngleY, 0);


        Vector3 distanceDiff = m_resetTransform.position - m_playerCam.transform.position;


        m_player.transform.position += distanceDiff;
    }



}
