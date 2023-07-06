using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] float effectTime;


    private void Start()
    {
        Destroy(gameObject, effectTime);
    }
}
