using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas _settingUICanvas;
    public GameObject _mainUICanvas;
    public GameObject _startUICanvas;
    public GameObject _exitUICanvas;

    public void ChangeMainCanvas()
    {
        if(_settingUICanvas.gameObject.activeSelf == false)
        {
            _settingUICanvas.gameObject.SetActive(true);
            _mainUICanvas.gameObject.SetActive(false);
        }
        else
        {
            _settingUICanvas.gameObject.SetActive(false);
            _mainUICanvas.gameObject.SetActive(true);
        }

    }

    public void ChangeStartCanvas()
    {
        if (_startUICanvas.gameObject.activeSelf == false)
        {
            _startUICanvas.gameObject.SetActive(true);
            _mainUICanvas.gameObject.SetActive(false);
        }
        else
        {
            _startUICanvas.gameObject.SetActive(false);
            _mainUICanvas.gameObject.SetActive(true);
        }

    }

    public void ChangeExitCanvas()
    {
        if (_exitUICanvas.gameObject.activeSelf == false)
        {
            _exitUICanvas.gameObject.SetActive(true);
            _mainUICanvas.gameObject.SetActive(false);
        }
        else
        {
            _exitUICanvas.gameObject.SetActive(false);
            _mainUICanvas.gameObject.SetActive(true);
        }

    }

}
