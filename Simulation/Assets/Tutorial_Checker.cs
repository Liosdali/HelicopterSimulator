using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialEnum
{
    switchCover,
    switchOff,
    keyOff,
    cyclicStick,
    throttlePower,
    collectiveLever
}



public class Tutorial_Checker : MonoBehaviour
{


    [SerializeField]
    private InteractableMission[] m_dialogues;

    [SerializeField]
    private UIDialogueTextBoxController m_DialogueController;

    private TutorialLines m_LineRenderer;

    // Düðme kapaðýný kaldýrýn (arka tuþa basabilirsiniz)
    // Düðmeyi tuþa basýlý tutarken ileri doðru ittirin
    // Güç çarpanýný arttýrmak için sol üstteki gaz kolunu ileriye doðru ittirin
    // Ortanýzda bulunan kontrol çubuðunu tutun. Bu çubuk ile helikoptere yön verebilirsiniz
    // Sol altýnýzda bulunan çubuk ile helikopterin yukarý veya aþaðý çýkmasýný saðlayabilirsiniz
    // Helikopteri baþlatmak için Marþý açýn (Anahtarýn üstüne geldiðinde arka tuþa basýnýz)


    private List<TutorialEnum> m_EnumList;

    
    [SerializeField]
    private TutorialEnum stepCase = TutorialEnum.switchCover;


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

        m_EnumList = new List<TutorialEnum>();

        m_EnumList.Add(TutorialEnum.switchOff);      
        m_EnumList.Add(TutorialEnum.throttlePower);
        m_EnumList.Add(TutorialEnum.collectiveLever);
        m_EnumList.Add(TutorialEnum.cyclicStick);
        m_EnumList.Add(TutorialEnum.keyOff);

    }
    private int count = 0;

    public bool NextTutorialObjective(TutorialEnum type)
    {
        if (type == stepCase)
        {
            Debug.LogError(stepCase.ToString() + "next ");
            if (count < m_EnumList.Count)
                stepCase = m_EnumList[count];
            count++;
            Debug.LogError(stepCase.ToString());
            m_LineRenderer.UpdateSecPos();
            m_DialogueController.NextDialogueTuto(); //Next dialogue can be used too 
            return true;
        }
        return false;
    }

    public bool KeyCheck(TutorialEnum type)
    {
        if (type == stepCase)
        {
            EndTutorial();
            return true;
        }
        return false;
    }

    public void EndTutorial()
    {
        m_DialogueController.NextDialogueTuto();
        m_DialogueController.FlipTutorial();
        m_LineRenderer.DeactivateLineRenderer();
        m_DialogueController.NextDialogueTuto();
        m_dialogues[1].OpenDialoge();
        Destroy(gameObject);

        // change dialogue to the newer one 
    }



    //interactable mission 


}
