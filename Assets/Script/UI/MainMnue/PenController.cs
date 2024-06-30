using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenController : IPointBase
{
    private Animator ani;
    private int index;

    private void Start()
    {
        index = 1;
        ani = GetComponent<Animator>();
        MonoController.Instance.AddUpdateListener(() => ChangeAnimation());
    }

    public override void Enter()
    {
        GameObject go = GameObject.FindGameObjectWithTag(gameObject.name);
        Image image = go.GetComponent<Image>();
        image.DOFade(1f, 0.2f);
        base.Enter();
    }

    public override void Exit()
    {
        GameObject go = GameObject.FindGameObjectWithTag(gameObject.name);
        Image image = go.GetComponent<Image>();
        image.DOFade(0f, 0.2f);
        base.Exit();
    }

    public override void Down()
    {
        if(index ==3)
        {
            index = 1;
        }
        else
        {
            index++;
        }
        EventCenter.Instance.EventTrigger<int>(gameObject.name, index);
        AudioMag.Instance.PlayOneShot("Audio/MainMnue/MainMnue_Pen_2");
        base.Down();
    }

    private void ChangeAnimation()
    {
        switch (index)
        {
            case 1:
                ani.SetBool("toHead", false);
                ani.SetBool("toBody", false);
                ani.SetBool("toHeart", true);
                break;
            case 2:
                ani.SetBool("toHead", true);
                ani.SetBool("toBody", false);
                ani.SetBool("toHeart", false);
                break;
            case 3:
                ani.SetBool("toHead", false);
                ani.SetBool("toBody", true);
                ani.SetBool("toHeart", false);
                break;
        }
    }
}
