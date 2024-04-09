using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class IPointBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,IDragHandler,IInitializePotentialDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler,IPointerUpHandler
{
    //点击
    public void OnPointerClick(PointerEventData eventData)
    {

        Click();
    }


    /// <summary>
    /// 点击接口
    /// </summary>
    public virtual void Click()
    {
        Debug.Log("点击");
    }

    //鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }

    /// <summary>
    /// 鼠标进入接口
    /// </summary>
    public virtual void Enter()
    {
        Debug.Log("进入区域");
    }
    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }

    /// <summary>
    /// 鼠标离开接口
    /// </summary>
    public virtual void Exit()
    {
        Debug.Log("离开区域");
    }
    //点击并且拖动
    public void OnDrag(PointerEventData eventData)
    {
        DownAndDrag();
    }


    /// <summary>
    /// 拖拽接口
    /// </summary>
    public virtual void DownAndDrag()
    {
        Debug.Log("点击并且拖拽"+ name);
    }
    //点击但不拖动
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Down();
    }

    /// <summary>
    /// 按下接口
    /// </summary>
    public virtual void Down()
    {
        Debug.Log("点击"+ name);
    }
    //鼠标抬起
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }


    /// <summary>
    /// 鼠标抬起
    /// </summary>
    public virtual void EndDrag()
    {
        Debug.Log("抬起"+ name);
    }

    //鼠标按下并开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDrag();
    }



    /// <summary>
    /// 拖拽
    /// </summary>
    public virtual void BeginDrag()
    {
        Debug.Log("点击并且开始拖拽"+ name);
    }

    //拖拽后放置
    public void OnDrop(PointerEventData eventData)
    {
        DropTo();
        Debug.Log(eventData.pointerDrag.name + "作用对象：" + name);
    }

    /// <summary>
    /// 拖拽后放置
    /// </summary>
    public virtual void DropTo()
    {
        Debug.Log("点击拖拽并放置" + name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpTo();
    }


    /// <summary>
    /// 鼠标抬起
    /// </summary>
    public virtual void UpTo()
    {
        Debug.Log("鼠标抬起");
    }
}
