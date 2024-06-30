using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : IPointBase
{
    Animator ani;
    bool isDown;

    private void Start()
    {
        ani = GetComponent<Animator>();
        isDown = false;
    }


    public override void Down()
    {

        AudioMag.Instance.PlayOneShot("Audio/MainGame/Button");

        base.Down();
        if(!isDown)
        {
            ani.SetBool("isDown", true);
            EventCenter.Instance.EventTrigger("«–ªª÷Á“π");
            isDown = true;
        }
        else if(isDown)
        {
            ani.SetBool("isDown", false);
            EventCenter.Instance.EventTrigger("«–ªª÷Á“π");
            isDown = false;
        }
    }


}
