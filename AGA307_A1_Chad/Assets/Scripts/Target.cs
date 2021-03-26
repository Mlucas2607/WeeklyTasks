using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        //SetUp();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("ChangeAnimation");
            //anim.SetBool("useSpin", !anim.GetBool("useSpin"));
        }
    }

}
