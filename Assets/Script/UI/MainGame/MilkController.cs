using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkController : IPointBase
{
    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public override void Down()
    {
        base.Down();
        ani.SetBool("Down", true);
        EventCenter.Instance.EventTrigger(gameObject.name);
    }

    public override void UpTo()
    {
        base.EndDrag();
        Debug.LogWarning("Ì§Æð");
        ani.SetBool("Down", false);
    }
}
