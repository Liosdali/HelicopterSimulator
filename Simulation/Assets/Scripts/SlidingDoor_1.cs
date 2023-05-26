using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Redundant class not being used anymore

public class SlidingDoor_1 : MonoBehaviour
{
    public float duration = 1f;
    public float loweredLeft = 1.5f;

    private bool _lowerDoor = false;
    private Vector3 _raisedPosition;
    void Start()
    {
        _raisedPosition = transform.position;
    }

    public void ToggleDoorOpen()
    {
        StopAllCoroutines();
        if (!_lowerDoor)
        {
            Vector3 lowerPosition = _raisedPosition + Vector3.forward * loweredLeft;
            StartCoroutine(MoveDoor(lowerPosition));
            _lowerDoor = !_lowerDoor;
        }
        else
        {
            StartCoroutine(MoveDoor(_raisedPosition));
            _lowerDoor = !_lowerDoor;
        }

        IEnumerator MoveDoor(Vector3 targetPosition)
        {
            float timeElapsed = 0;
            Vector3 startPosition = transform.position;
            while (timeElapsed < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }
    }
}

