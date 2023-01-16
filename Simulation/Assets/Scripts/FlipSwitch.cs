using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipSwitch : MonoBehaviour
{

    private bool switch_Hit = false;

    private bool switch_Pos = false;  //Switch's starting position


    [SerializeField]
    private float rotation = 100f;


    [System.Serializable] public class InteractionEvent : UnityEvent { }

    public InteractionEvent onFlipOn = new InteractionEvent();
    public InteractionEvent onFlipOff = new InteractionEvent();

    // Update is called once per frame
    void Update()
    {
        
        if (switch_Hit)
        {
            switch_Hit = false;


            switch_Pos = !switch_Pos;

            if (switch_Pos)
            {
                transform.rotation = Quaternion.Euler(0,transform.eulerAngles.y + rotation,0);
                onFlipOn.Invoke();
                Debug.Log("PlayerTouched");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - rotation, 0);
                onFlipOff.Invoke();
                Debug.Log("PlayerTouched");
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            //If Player Touches it will change the 
            switch_Hit = true;
        }
    }
}
