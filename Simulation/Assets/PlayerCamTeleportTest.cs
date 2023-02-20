using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamTeleportTest : MonoBehaviour
{
    [SerializeField] private Transform m_resetTransform;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Camera m_playerCam;


    // Start is called before the first frame update


    private bool m_isTeleporting = false;


    public void LateUpdate()
    {
        if (!m_isTeleporting)
        {
            ResetPosition();
            m_isTeleporting = true;
            //gameObject.SetActive(false);
        }
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
