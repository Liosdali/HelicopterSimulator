using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableMission : MonoBehaviour
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


    public void OpenDialoge()
    {
        dialogueBox.SetActive(true);
        DoInteraction();
    }


}
