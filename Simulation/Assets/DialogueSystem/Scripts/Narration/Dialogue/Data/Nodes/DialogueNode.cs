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




    //Private
    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    public AudioClip m_AudioClip;


    //


    public void AssignAudio()
    {
        m_AudioSource.clip = m_AudioClip;
    }


    public void PlayAudio()
    {
        Debug.Log("Playing Audio"); // + m_FirstNode.name);
        m_AudioSource.Play();
    }

    public void StopAudio()
    {
        Debug.Log("Stopping Audio"); //+ m_FirstNode.name);
        m_AudioSource.Stop();
    }
}