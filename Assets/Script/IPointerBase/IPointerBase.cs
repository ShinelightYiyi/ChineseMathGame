using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PointBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,IDragHandler,IInitializePotentialDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler
{
    //���
    public void OnPointerClick(PointerEventData eventData)
    {

        Click();
    }

    public virtual void Click()
    {
        Debug.Log("���");
    }

    //������
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }
    public virtual void Enter()
    {
        Debug.Log("��������");
    }
    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }
    public virtual void Exit()
    {
        Debug.Log("�뿪����");
    }
    //��������϶�
    public void OnDrag(PointerEventData eventData)
    {
        DownAndDrag();
    }

    public virtual void DownAndDrag()
    {
        Debug.Log("���������ק"+ name);
    }
    //��������϶�
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Down();
    }

    public virtual void Down()
    {
        Debug.Log("���"+ name);
    }
    //���̧��
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }

    public virtual void EndDrag()
    {
        Debug.Log("̧��"+ name);
    }

    //��갴�²���ʼ��ק
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDrag();
    }

    public virtual void BeginDrag()
    {
        Debug.Log("������ҿ�ʼ��ק"+ name);
    }

    //��ק�����
    public void OnDrop(PointerEventData eventData)
    {
        DropTo();
        Debug.Log(eventData.pointerDrag.name + "���ö���" + name);
    }

    public virtual void DropTo()
    {
        Debug.Log("�����ק������" + name);
    }
}
