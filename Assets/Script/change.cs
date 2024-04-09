using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// this is an class witch inherit from PointBase.
/// it should attached with the imageobject.
/// </summary>
public class change : PointBase
{
    public static int isclick = 0;
    // Start is called before the first frame update
    public override void Click()
    {
        base.Click();
        imagechange0();
    }

    /// <summary>
    /// this funcation can instantiate an obj with the interface namde"imagechange"
    /// </summary>
    public void imagechange0()
    {
        Image image = GetComponent<Image>();
        imagechange obj = new Onimagechange();

        obj.OnImageChange(image);
        isclick++;
        // if u click the image,this variable will increase and there will be some logic judge in ChangeControllor
    }
}

//the interface about imagechange, we can modify this interface to change the pointevent;
interface imagechange
{
    void OnImageChange(Image image);
}