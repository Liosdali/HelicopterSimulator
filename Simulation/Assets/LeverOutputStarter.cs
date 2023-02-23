using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LeverOutputStarter : MonoBehaviour
{



    // ---------------------------- Events
    public class InteractionEvent : UnityEvent { }

    public InteractionEvent onFlipOn = new InteractionEvent();
    public InteractionEvent onFlipOff = new InteractionEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
