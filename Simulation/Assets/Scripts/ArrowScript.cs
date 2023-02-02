using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    [SerializeField]
    private Transform _Target;
    public Transform LookAtTarget { get { return _Target; } }


    [SerializeField]
    private Transform _Spinner;
    public Transform Spinner { get { return _Spinner; } }

    [SerializeField]
    private Transform _Scaler;
    public Transform Scaler { get { return _Scaler; } }

    public static ArrowScript Instance;

    public float _TurnSpeed;
    public void SetTarget(Transform target = null)
    {
        _Target = target;
    }
    private void Awake()
    {
        // Singleton
        Instance = this;
    }

    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LookAtTarget)
        {
            transform.LookAt(LookAtTarget);
        }
        if (Spinner)
        {
            Spinner.transform.Rotate(0,0,_TurnSpeed * Time.deltaTime);
        }
    }


    public void EndArrow ()
    {
        SetTarget(null);
        this.gameObject.SetActive(false);
    }

    public void StartArrow(Transform target)
    {
        this.gameObject.SetActive(true);
        SetTarget(target);
    }
}
