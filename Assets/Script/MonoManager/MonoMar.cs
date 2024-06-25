using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoMar : MonoBehaviour
{
    private static UnityAction updateEvent;



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    private void Update()
    {
        if(updateEvent != null)
        {
            updateEvent();
        }
    }



    public void AddUpdateListener(UnityAction action)
    {
        updateEvent += action;
    }

    public void RemoveUpdateListener(UnityAction action)
    {
        updateEvent -= action;
    }


    /// <summary>
    /// ����¼����л�����ʱʹ��
    /// </summary>
    public void Clear()
    {
        updateEvent = null;
    }
}
