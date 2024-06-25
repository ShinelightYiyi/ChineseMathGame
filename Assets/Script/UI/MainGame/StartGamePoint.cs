using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartGamePoint : IPointBase
{
    [SerializeField] Transform p1, p2;


    public override void Enter()
    {
        base.Enter();
        gameObject.transform.DOMove(p2.transform.position, 0.2f);
    }

    public override void Exit()
    {
        base.Exit();
        gameObject.transform.DOMove(p1.transform.position, 0.2f);
    }

    public override void Down()
    {
        base.Down();
        EventCenter.Instance.EventTrigger("¿ªÊ¼ÓÎÏ·");
        gameObject.SetActive(false);
    }
}
