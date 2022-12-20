using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{

    [SerializeField]
    AudioSource audioSource;


    [SerializeField]
    private DialogueNode m_FirstNode;
    public DialogueNode FirstNode => m_FirstNode;
}