using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private float m_range = 0f;

    private MeshRenderer m_renderer;


    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, m_player.transform.position) < m_range)
            m_renderer.enabled = false;
        else
            m_renderer.enabled = true;
    }
}
