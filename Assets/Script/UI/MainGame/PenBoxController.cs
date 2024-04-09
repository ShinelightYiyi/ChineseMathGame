using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenBoxController : IPointBase
{
    [SerializeField] Animator ani;

    private void Start()
    {

    }
    public override void Down()
    {
        base.Down();
        ani.SetBool("Down", true);
        EventCenter.Instance.EventTrigger("µã»÷±ÊºÐ");
    }

    public override void UpTo()
    {
        base.EndDrag();
        Debug.LogWarning("Ì§Æð");
        ani.SetBool("Down", false);
    }
}
