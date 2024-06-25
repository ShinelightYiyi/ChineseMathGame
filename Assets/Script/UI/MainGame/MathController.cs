using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathController : IPointBase
{
    private int index;
    [SerializeField] GameObject[] gameObjects;

    private void Start()
    {
        index = 1;
        EventCenter.Instance.EventTrigger<int>("»Ã·½1", index);
    }


    public override void Down()
    {
        base.Down();
        if(index ==3)
        {
            index = 1;
        }
        else
        {
            index++;
        }
        EventCenter.Instance.EventTrigger<int>("»Ã·½1", index);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }


}
