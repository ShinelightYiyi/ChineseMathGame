using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PointBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,IDragHandler,IInitializePotentialDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler
{
    //点击
    public void OnPointerClick(PointerEventData eventData)
    {

        Click();
    }

    public virtual void Click()
    {
        Debug.Log("点击");
    }

    //鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }
    public virtual void Enter()
    {
        Debug.Log("进入区域");
    }
    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }
    public virtual void Exit()
    {
        Debug.Log("离开区域");
    }
    //点击并且拖动
    public void OnDrag(PointerEventData eventData)
    {
        DownAndDrag();
    }

    public virtual void DownAndDrag()
    {
        Debug.Log("点击并且拖拽"+ name);
    }
    //点击但不拖动
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Down();
    }

    public virtual void Down()
    {
        Debug.Log("点击"+ name);
    }
    //鼠标抬起
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }

    public virtual void EndDrag()
    {
        Debug.Log("抬起"+ name);
    }

    //鼠标按下并开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDrag();
    }

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

    public virtual void DropTo()
    {
        Debug.Log("点击拖拽并放置" + name);
    }
}
