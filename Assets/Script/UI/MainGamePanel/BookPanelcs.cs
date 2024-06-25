using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class BookPanel : BasePanel
{
    private static string name = "BookPanel";
    private static string path = "UIPanel/MainGame/BookPanel";

    private static UIType newUIType = new UIType(name,path);
    public BookPanel() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("推入");
    }
}
