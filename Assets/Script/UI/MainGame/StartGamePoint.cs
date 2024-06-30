using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartGamePoint : IPointBase
{



    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Down()
    {
        base.Down();
        EventCenter.Instance.EventTrigger("¿ªÊ¼ÓÎÏ·");
        AudioMag.Instance.PlayOneShot("Audio/MainGame/MainGame_TurnPage");
    }
}
