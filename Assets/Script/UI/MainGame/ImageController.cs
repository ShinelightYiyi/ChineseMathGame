using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageController : IPointBase
{

    Image image;
    bool isLight;

    private void Start()
    {
        isLight = true;
        image = GetComponent<Image>();
        EventCenter.Instance.AddEventListener("ÇÐ»»ÖçÒ¹", () => ChangeLight());
    }

    public override void Enter()
    {
        base.Enter();
        image.color = new Color(0.85f, 0.85f, 0.85f);
        gameObject.transform.DOScale(1.1f, 0.2f);
    }


    public override void Exit()
    {
        base.Exit();
        image.color = new Color(1f, 1f, 1f);
        gameObject.transform.DOScale(1f, 0.2f);
    }


    public override void Down()
    {
        base.Down();
        AudioMag.Instance.PlayOneShot("Audio/MainGame/Card");
        if (isLight)
        {
            gameObject.transform.DOScale(0.9f, 0.2f);

            EventCenter.Instance.EventTrigger<int>("µã»÷", int.Parse(gameObject.name));
        }
    }

    private void ChangeLight()
    {
        isLight = !isLight;
    }


}
