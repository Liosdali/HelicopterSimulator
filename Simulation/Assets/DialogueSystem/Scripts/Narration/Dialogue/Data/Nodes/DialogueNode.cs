using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
    private NarrationLine m_DialogueLine;

    public NarrationLine DialogueLine => m_DialogueLine;
    //public
    public abstract bool CanBeFollowedByNode(DialogueNode node);
    public abstract void Accept(DialogueNodeVisitor visitor);


    [SerializeField]
    private AudioClip m_AudioClip;

    public AudioClip GetAudioClip()
    {
        return m_AudioClip;
    }
}