using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeHeliPos : MonoBehaviour
{

    private Rigidbody m_rigidbody;

    private bool freeze = false;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (freeze)
    //    {
    //        m_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    //    }
    //    if (!freeze)
    //    {
    //        m_rigidbody.constraints = RigidbodyConstraints.None;
    //    }
    //}
    // Freezing helicopter position by the usage of rigidbody constraints

    public void  FreezeHelicopterPos()
    {
        m_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }
    
    public void UnlockHeliPos()
    {
        m_rigidbody.constraints = RigidbodyConstraints.None;
    }


    public void isButtonPressed()
    {
        freeze = !freeze;
    }
}