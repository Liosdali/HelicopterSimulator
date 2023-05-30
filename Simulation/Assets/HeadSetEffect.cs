using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetEffect : MonoBehaviour
{

    Renderer[] renderers;

    public void OnHoverEnter()
    {
        renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }
    public void OnHoverExit()
    {
        renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.material.DisableKeyword("_EMISSION");
        }
    }
}
