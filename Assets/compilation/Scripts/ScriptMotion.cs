using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMotion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gb;

    private Animator anim;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.SetBool("stop", true);
            childframe.SetActive(false);
            anim.SetBool("jump", false);
        }*/
    }

}
