using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenHeadController : IPointBase
{

    Image image;
    bool isOnce;

    private void Start()
    {
        EventCenter.Instance.AddEventListener("ÇÐ»»Î»ÖÃ", () => ChangePosition());
        image = GetComponent<Image>();
        isOnce = true;
    }

    public override void Enter()
    {
        base.Enter();
        image.color = new Color(0.85f, 0.85f, 0.85f);
    }

    public override void Exit()
    {
        base.Exit();
        image.color = new Color(1f,1f, 1f); 
    }


    public override void Click()
    {
        base.Click();
        if (isOnce)
        {
            image.color = new Color(0.7f, 0.7f, 0.7f);
            gameObject.transform.DOScale(0.9f, 0.2f);
            isOnce = false;
        }
        else
        {
            image.color = new Color(1, 1, 1);
            gameObject.transform.DOScale(1f, 0.2f);
            isOnce=true;
        }
        EventCenter.Instance.EventTrigger(gameObject.name + "±»µã»÷");
    }

    private void ChangePosition()
    {
        image.color = new Color(1, 1, 1);
        gameObject.transform.DOScale(1f, 0.2f);
        isOnce = true;
    }


}
