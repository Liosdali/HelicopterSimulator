using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanel : MonoBehaviour
{

    public int MissionCount = 0;
    private int m_countNo = 0;

    [SerializeField]
    private Text m_Text;



    public void UpdateText()
    {
        m_countNo++;
        m_Text.text = m_countNo.ToString() + "/" + MissionCount.ToString();
    }
}
