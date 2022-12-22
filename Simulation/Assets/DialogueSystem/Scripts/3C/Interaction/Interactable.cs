using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    UnityEvent m_OnInteraction;

    public void DoInteraction()
    {
        m_OnInteraction.Invoke();
        
    }

    private void Start()
    {
        dialogueBox.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            dialogueBox.SetActive(true);
            DoInteraction();
        }
    }
}

//