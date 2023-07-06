using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<MagicBase> magics;
    [SerializeField] float projectileCoolDown;
    private bool canAttack;



    private void Start()
    {
        canAttack = true;
    }
    private void Update()
    {   
        if (canAttack ==false)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                magics[0].Magic();
                StartCoroutine(CoolDown(projectileCoolDown));
            }
        }

        

    }

    IEnumerator CoolDown(float cooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
    
}
