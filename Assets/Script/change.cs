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
public class Change : IPointBase
{
    private int isclick = 1;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (isclick)
        {
            case 1:
                ani.SetBool("ToFriend", true);
                ani.SetBool("ToFamily", false);
                ani.SetBool("ToStudy", false);
                break;
            case 2:
                ani.SetBool("ToFriend", false);
                ani.SetBool("ToFamily", true);
                ani.SetBool("ToStudy", false);
                break;
            case 3:
                ani.SetBool("ToFriend", false);
                ani.SetBool("ToFamily", false);
                ani.SetBool("ToStudy", true);
                break;
        }
    }
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
        isclick++;
        if(isclick > 3)
        {
            isclick = 1;
        }
        Debug.Log("´«³ö"+gameObject.name);
        EventCenter.Instance.EventTrigger<int>(gameObject.name , isclick);
    }
}


