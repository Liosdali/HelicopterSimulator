using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;



public class UIDialogueTextBoxController : MonoBehaviour, DialogueNodeVisitor
{
    //-------------------------------------------------------------SerializeField
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

    //-------------------------------------------------------------InputMapping
    private InputAction _selectmenu;
    public InputActionAsset inputActions;
    //------------------------------------------------------------DialogueMapping
    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;
    //-------------------------------------------------------------Audio
    public AudioSource m_DialogueSource;

    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        //m_AudioSource = GetComponent<AudioSource>();

        //m_AudioSource = 
        //m_AudioSource = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);

        m_DialogueSource =GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    private void Start()
    {

        _selectmenu = inputActions.FindActionMap("XRI Wrist Menu").FindAction("DialogueSkip");
        _selectmenu.Enable();
        //_selectmenu.performed += ToggleSelectMenu;
        //m_DialogueSource.clip = m_NextNode.GetAudioClip();
        PlayAudio();
    }

    //public void ToggleSelectMenu(InputAction.CallbackContext context)
    //{
    //    if (m_ListenToInput)
    //    {
    //        //PlayAudio();
    //        Debug.Log("Next Dialogue");
    //        PlayNextAudio();
    //        m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);

    //    }
    //}


    public bool tutorialPhase;


    private void Update()
    {
        if (!tutorialPhase)
        {
            if (!m_DialogueSource.isPlaying) { NextDialogue(); }
        }
    }

    //public void ToggleSelectMenu(InputAction.CallbackContext context)
    //{
    //    if (!m_DialogueSource.isPlaying)
    //    {
    //        //PlayAudio();
    //        Debug.Log("Next Dialogue");
    //        PlayNextAudio();
    //        m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);

    //    }
    //}

    public void NextDialogue()
    {
        if (m_NextNode != null)
        {
            if (!m_DialogueSource.isPlaying)
            {
                //PlayAudio();
                Debug.Log("Next Dialogue");
                PlayNextAudio();
                m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);

            }
        }
    }



    private void PlayFirstAudio()
    {
        m_DialogueSource.Play();
    }
    public void PlayAudio()
    {
        m_DialogueSource.Stop();

        if (m_NextNode != null)
        {
            //Debug.Log("Ýsim burada = " + m_NextNode.GetAudioClip().name);
            //m_DialogueSource.clip = m_NextNode.GetAudioClip();
            m_DialogueSource.Play();
        }

    }
    public void PlayNextAudio()
    {
        m_DialogueSource.Stop();

        if (m_NextNode != null)
        {
            //Debug.Log("Ýsim burada = " + m_NextNode.GetAudioClip().name);
            m_DialogueSource.clip = m_NextNode.GetAudioClip();
            m_DialogueSource.Play();
        }

    }
    private void OnDialogueNodeStart(DialogueNode node)
    {
        //AudioTest();
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
        if (m_NextNode == null)
        { 
            m_DialogueSource.clip = node.GetAudioClip();
            PlayFirstAudio();
        }
        //PlayAudio();
        m_ListenToInput = true;
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