using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    public GameObject hoverEffectPrefab;

    public void ActivateButtonEffect()
    {
        hoverEffectPrefab.SetActive(true);
    }

    public void DisActivateButtonEffect()
    {
        hoverEffectPrefab.SetActive(false);
    }
}
