using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPanelC : BasePanel
{

    private static string name = "BookPanelC";
    private static string path = "UIPanel/MainGame/BookPanelC";
    private static UIType newUIType = new UIType(name, path);
    public BookPanelC() : base(newUIType)
    {

    }
}
