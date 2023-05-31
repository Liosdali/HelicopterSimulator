using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FadeScript : MonoBehaviour
{


    //Fade script need refining

    [SerializeField] private float _FadeDuration = 2f;
    [SerializeField] private Color _FadeColor = Color.black;
    [SerializeField] private bool _fadeOnStart = false;

    private float _time;
    
    private Renderer _renderer;


    public static FadeScript instance;

    // Getting renderer component in the start of the scene
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        XRSettings.gameViewRenderMode = GameViewRenderMode.LeftEye;
        instance = this;
        
    }

    private void Update()
    {
        if (_fadeOnStart)
        {
            EndCutscene();
            _fadeOnStart = false;
        }
    }

    public void ChangeFadeStart()
    {
        _fadeOnStart = true;
    }



    public void EndCutscene()
    {
        StartCoroutine(BlackCourutine());
    }


    public void FadeIn()
    {
        FadeFunction(1, 0);
    }
    public void FadeOut()
    {
        FadeFunction(0, 1);
    }

    private void FadeFunction(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeCourutine(alphaIn, alphaOut));
    }


    // Making the first scene black
     
    private IEnumerator BlackCourutine()
    {
        float timer = 0f;
        Color _fadeColor = _FadeColor;
        _fadeColor.a = 1;
        _renderer.material.SetColor("_Color", _fadeColor);

        while (timer <= _FadeDuration)
        {
            Debug.Log("Starting the Project");
            timer += Time.deltaTime;
            yield return null;
        }
        //
        PlayerCamTeleport.instance.ResetPosition();
        
        
        
        PlayerCheck.FlipUpdate();
        FadeIn();
    }


    // 

    private IEnumerator FadeCourutine(float alphaIn, float alphaOut)
    {

        float timer = 0f;

        while (timer <= _FadeDuration) {

            Debug.Log("Fade + + ");
            timer += Time.deltaTime;
            Color _fadeColor = _FadeColor;

            _fadeColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / _FadeDuration);

            _renderer.material.SetColor("_Color", _fadeColor);

            yield return null;
        }



        Color fadeColor2 = _FadeColor;

        fadeColor2.a = alphaOut;

        _renderer.material.SetColor("_Color", fadeColor2);

        gameObject.SetActive(false);
        Tutorial_Checker.Instance.Instantiate();
        
        Destroy(gameObject);
    }
}
