using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Checker : MonoBehaviour
{

    enum Tutorial
    {
        switchCover,
        switchOff,
        keyOff,
        cycliclStick,
        throttlePower,
        collectiveLever
    }

    [SerializeField]
    private InteractableMission[] m_dialogues;

    [SerializeField]
    private UIDialogueTextBoxController m_DialogueController;

    private TutorialLines m_LineRenderer;

    // Düðme kapaðýný kaldýrýn (Sol arka tuþa basabilirsiniz)
    // Düðmeyi tuþa basýlý tutarken ileri doðru ittirin
    // Güç çarpanýný arttýrmak için sol üstteki gaz kolunu ileriye doðru ittirin
    // Ortanýzda bulunan kontrol çubuðunu tutun. Bu çubuk ile helikoptere yön verebilirsiniz
    // Sol altýnýzda bulunan çubuk ile helikopterin yukarý veya aþaðý çýkmasýný saðlayabilirsiniz
    // Helikopteri baþlatmak için Marþý açýn (Anahtarýn üstüne geldiðinde arka tuþa basýnýz)


    public static Tutorial_Checker Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_LineRenderer = GetComponent<TutorialLines>();

    }

    public void Instantiate()
    {
        Debug.LogError("Instantiating");
        m_LineRenderer.ActivateLineRenderer();
        m_LineRenderer.m_fixPoint = true;
        m_dialogues[0].OpenDialoge();


    }


    public void NextTutorialObjective()
    {
        m_LineRenderer.UpdateSecPos();
        m_DialogueController.NextDialogueTuto(); //Next dialogue can be used too 
    }


    public void EndTutorial()
    {
        m_DialogueController.FlipTutorial();
        m_LineRenderer.DeactivateLineRenderer();


        Destroy(gameObject);
        // change dialogue
    }



    //interactable mission 


}
