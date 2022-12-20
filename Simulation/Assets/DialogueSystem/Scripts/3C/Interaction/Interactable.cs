using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    UnityEvent m_OnInteraction;

    public void DoInteraction()
    {
        m_OnInteraction.Invoke();
        
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            DoInteraction();
        }
    }
}

//