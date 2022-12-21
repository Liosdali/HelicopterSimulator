using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class UIDialogueTextBoxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private TextMeshProUGUI m_SpeakerText;
    [SerializeField]
    private TextMeshProUGUI m_DialogueText;

    [SerializeField]
    private RectTransform m_ChoicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController m_ChoiceControllerPrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;


    private AudioSource m_AudioSource;
    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        m_AudioSource = GetComponent<AudioSource>();
        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    private float waitSeconds = 1.0f;
    private void Update()
    {
         
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        UnityEngine.XR.InputDevice device = rightHandDevices[0];
        Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        bool triggerValue;
        if ((waitSeconds < 0.0f)  && m_ListenToInput && device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            
            waitSeconds = 1.0f;
            Debug.Log("Next Dialogue");
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
            StopAudio();
            if (m_NextNode.DialogueLine.audioClip != null)
                Debug.Log(m_NextNode.DialogueLine.audioClip.name);
            m_AudioSource.clip = m_NextNode.DialogueLine.audioClip;
            PlayAudio();
        }

        waitSeconds -= Time.deltaTime;
    }
    private bool playing = false;
    public void PlayAudio()
    {
        if (m_AudioSource != null && m_AudioSource.clip != null)
        {

            Debug.Log("Radio Starting to Play" + m_AudioSource.clip.name);
            m_AudioSource.Play();
        }
    }


    public void StopAudio()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.Stop();
        }
    }
    
    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        m_DialogueText.text = node.DialogueLine.Text;
        m_SpeakerText.text = node.DialogueLine.Speaker.CharacterName;
        
        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        m_NextNode = null;
        m_ListenToInput = false;
        m_DialogueText.text = "";
        m_SpeakerText.text = "";

        foreach (Transform child in m_ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        //node.DialogueLine.PlayAudio();
        m_NextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        m_ChoicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueChoiceController newChoice = Instantiate(m_ChoiceControllerPrefab, m_ChoicesBoxTransform);
            newChoice.Choice = choice;
        }
    }
}