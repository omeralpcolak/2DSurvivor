using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBase : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public virtual void Magic()
    {

    }
}
