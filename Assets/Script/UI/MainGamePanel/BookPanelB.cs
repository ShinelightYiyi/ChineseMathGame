using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzleB : BasePanel
{

    private static string name = "BookPanelB";
    private static string path = "UIPanel/MainGame/BookPanelB";
    private static UIType newUIType = new UIType(name, path);
    public BookPuzzleB() : base(newUIType)
    {

    }
}
