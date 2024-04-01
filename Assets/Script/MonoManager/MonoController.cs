using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MonoController
{
    private static MonoController instance;

    public static MonoController Instance { get => instance ?? (instance = new MonoController()); }
    //单例模式

    private static MonoMar controller;

    public MonoController()
    {
        if(controller == null)
        {
            GameObject obj = new GameObject("MonoController");
            controller = obj.AddComponent<MonoMar>();
        }
    }

    public void AddUpdateListener(UnityAction action)
    {
        controller.AddUpdateListener(action);
    }

    public void RemoveUpdateListener(UnityAction action)
    {
        controller.RemoveUpdateListener(action);
    }



    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }

    public Coroutine StartCoroutine(string methodName, object value)
    {
        return controller.StartCoroutine(methodName, value);
    }

    public Coroutine StartCoroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }

}
