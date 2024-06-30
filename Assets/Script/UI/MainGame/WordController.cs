using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WordController : IPointBase
{
    Animator ani;
    Image image;
    bool isLight;
    bool isDown;
    int a;

    private void Start()
    {
        ani = GetComponent<Animator>();
        image = GetComponent<Image>();

        isDown = false;
        isLight = true;


        int.TryParse(gameObject.tag.ToString(), out a);
        EventCenter.Instance.AddEventListener("ÇÐ»»ÖçÒ¹", () => ChangeCodition());
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
        image.color = new Color(0.7f, 0.7f, 0.7f);
        if (isLight)
        {
            EventCenter.Instance.EventTrigger<int>("µã»÷", a);
            gameObject.transform.DOScale(0.9f, 0.2f);
        }

        if(!isLight)
        {
            if (!isDown)
            {
                gameObject.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutElastic).OnComplete(() => ani.SetBool("isDown", true));
                if(gameObject.name == "a1")
                {
                    gameObject.name = "b1";
                }
                else if(gameObject.name == "a2")
                {
                    gameObject.name = "b2";
                }
                else if(gameObject.name == "a3")
                {
                    gameObject.name = "b3";
                }
                isDown = true;
            }
            else if(isDown)
            {
                gameObject.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutElastic).OnComplete(() => ani.SetBool("isDown", false));
                if (gameObject.name == "b1")
                {
                    gameObject.name = "a1";
                }
                else if (gameObject.name == "b2")
                {
                    gameObject.name = "a2";
                }
                else if (gameObject.name == "b3")
                {
                    gameObject.name = "a3";
                }
                isDown = false;
            }
        }
    }

    private void ChangeCodition()
    {
        isLight = !isLight;
    }
}
