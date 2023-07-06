using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSlide : MonoBehaviour
{

    bool sliding = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Sliding();
    }

    void Sliding()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(SlidingRoutine());
        }
    }

    IEnumerator SlidingRoutine()
    {
        sliding = true;
        anim.SetBool("isSliding", sliding);
        yield return new WaitForSeconds(.33f);
        sliding = false;
        anim.SetBool("isSliding", sliding);

    }
}
