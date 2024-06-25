using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FiveController : IPointBase
{
    Animator ani;
    private int nameNub;
    public float scale;

    private void Awake()
    {
        nameNub = int.Parse(gameObject.name);
        ani = GetComponent<Animator>();
    }

    public override void Down()
    {
        EventCenter.Instance.EventTrigger<int>("µã»÷»Ã·½" , nameNub);
        base.Down();
    }
    public override void Enter()
    {
        ani.SetBool("isEnter", true);
        gameObject.transform.DOScale(scale, 0.1f);
        base.Enter();
    }

    public override void Exit()
    {
        ani.SetBool("isEnter" ,false);
        gameObject.transform.DOScale(1.0f, 0.1f);
        base.Exit();
    }

}
