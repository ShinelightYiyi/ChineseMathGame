using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClassController : IPointBase
{
    Image image;
    int nub;

    private void Start()
    {
        nub = int.Parse(gameObject.name);

        image = GetComponent<Image>();

        EventCenter.Instance.AddEventListener("ÇÐ»»Î»ÖÃ", () => ChangePosition());
    }


    public override void Enter()
    {
        base.Enter();
        image.color = new Color(0.85f, 0.85f, 0.85f);
    }

    public override void Exit()
    {
        base.Exit();
        image.color = new Color(1, 1, 1);
    }

    public override void Down()
    {
        base.Down();
        image.color = new Color(0.6f, 0.6f, 0.6f);
        gameObject.transform.DOScale(0.9f, 0.2f);
        EventCenter.Instance.EventTrigger<int>("µã»÷", nub);
        AudioMag.Instance.PlayOneShot("Audio/MainGame/Card");
    }

    private void ChangePosition()
    {
        image.color = new Color(1, 1, 1);
        gameObject.transform.DOScale(1f, 0.2f);
    }


}
