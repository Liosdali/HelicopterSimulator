using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Checker : MonoBehaviour
{

    enum Tutorial
    {
        switchCover,
        switchOff,
        keyOff,
        cycliclStick,
        throttlePower,
        collectiveLever
    }

    public static Tutorial_Checker Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
