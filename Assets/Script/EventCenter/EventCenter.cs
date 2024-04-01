using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    //����۲���
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}  //���͹۲���  

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
} //�۲���  



public class EventCenter  //֪ͨ��
{
    private static EventCenter instance;
    public static EventCenter Instance { get => instance ?? (instance = new EventCenter()); }
    //����ģʽ  


    /// <summary>
    /// key--�¼���   value--��Ӧί��
    /// </summary>
    private static Dictionary<string , IEventInfo> eventDic = new Dictionary<string , IEventInfo>();



    /// <summary>
    /// Ϊ�¼���ӷ���ί��
    /// </summary>
    /// <typeparam ί������="T"></typeparam>
    /// <param name=ί����></param>
    /// <param name=����ί��></param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        //�Ƿ����ж�Ӧ�¼�  
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }


    /// <summary>
    /// Ϊ�¼����ί��
    /// </summary>
    /// <param name=ί����></param>
    /// <param name=����ί��></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// �Ƴ������¼�
    /// </summary>
    /// <typeparam ί������="T"></typeparam>
    /// <param name=�¼���></param>
    /// <param name=����ί��></param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }


    /// <summary>
    /// �Ƴ��¼�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }


    /// <summary>
    /// ���������¼�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="info"></param>
    public void EventTrigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null)
            {
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
            }
        }
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
            {
                (eventDic[name] as EventInfo).actions.Invoke();
            }
        }
    }

    /// <summary>
    /// ����ֵ䣬�л�����ʱʹ��
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }


}
