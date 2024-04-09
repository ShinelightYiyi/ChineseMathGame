using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class IPointBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler,IDragHandler,IInitializePotentialDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler,IPointerUpHandler
{
    //���
    public void OnPointerClick(PointerEventData eventData)
    {

        Click();
    }


    /// <summary>
    /// ����ӿ�
    /// </summary>
    public virtual void Click()
    {
        Debug.Log("���");
    }

    //������
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }

    /// <summary>
    /// ������ӿ�
    /// </summary>
    public virtual void Enter()
    {
        Debug.Log("��������");
    }
    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }

    /// <summary>
    /// ����뿪�ӿ�
    /// </summary>
    public virtual void Exit()
    {
        Debug.Log("�뿪����");
    }
    //��������϶�
    public void OnDrag(PointerEventData eventData)
    {
        DownAndDrag();
    }


    /// <summary>
    /// ��ק�ӿ�
    /// </summary>
    public virtual void DownAndDrag()
    {
        Debug.Log("���������ק"+ name);
    }
    //��������϶�
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Down();
    }

    /// <summary>
    /// ���½ӿ�
    /// </summary>
    public virtual void Down()
    {
        Debug.Log("���"+ name);
    }
    //���̧��
    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }


    /// <summary>
    /// ���̧��
    /// </summary>
    public virtual void EndDrag()
    {
        Debug.Log("̧��"+ name);
    }

    //��갴�²���ʼ��ק
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDrag();
    }



    /// <summary>
    /// ��ק
    /// </summary>
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

    /// <summary>
    /// ��ק�����
    /// </summary>
    public virtual void DropTo()
    {
        Debug.Log("�����ק������" + name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpTo();
    }


    /// <summary>
    /// ���̧��
    /// </summary>
    public virtual void UpTo()
    {
        Debug.Log("���̧��");
    }
}
