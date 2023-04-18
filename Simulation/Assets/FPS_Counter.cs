using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour
{
    private int _lastFrameIndex;
    private float[] _frameDeltaTimeArray;

    [SerializeField]
    private Text _fpsText;

    private void Awake()
    {
        _frameDeltaTimeArray = new float[50];
    }
    

    // Update is called once per frame
    void Update()
    {
        _frameDeltaTimeArray[_lastFrameIndex] = Time.deltaTime;
        _lastFrameIndex = (_lastFrameIndex + 1) % _frameDeltaTimeArray.Length;
        _fpsText.text = Mathf.RoundToInt(CalcFPS()).ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private float CalcFPS()
    {
        float fps = 0;

        foreach (float frame in _frameDeltaTimeArray)
        {
            fps += frame;
        }

        return _frameDeltaTimeArray.Length / fps;
    }


}
