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

    [SerializeField]
    public AudioSource[] m_AudioSource;
    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        //m_AudioSource = GetComponent<AudioSource>();

        //m_AudioSource = 
        //m_AudioSource = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    private float waitSeconds = 1.0f;
    int index = 0;
    private void Update()
    {

        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        UnityEngine.XR.InputDevice device = rightHandDevices[0];
        Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        bool triggerValue;
        if ((waitSeconds < 0.0f) && m_ListenToInput && device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
        {
            waitSeconds = 1.0f;
            Debug.Log("Next Dialogue");
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
            if (index >= m_AudioSource.Length)
                return;
            StopAudio(index);
            index++;
            //m_AudioSource = new AudioSource();
            //m_AudioSource = new AudioSource();
            //m_AudioSource.clip = m_NextNode.DialogueLine.audioClip;
            PlayAudio(index);
            //index++;

        }

        waitSeconds -= Time.deltaTime;
    }
    private bool playing = false;
    public void PlayAudio(int index)
    {
        if (m_AudioSource != null && m_AudioSource[index].clip != null)
        {
            m_AudioSource[0].Stop();
            Debug.Log("Radio Starting to Play" + m_AudioSource[index].clip.name);
            m_AudioSource[index].Play();
        }
    }


    public void StopAudio(int index)
    {
        if (m_AudioSource != null)
        {
            m_AudioSource[index].Stop();
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