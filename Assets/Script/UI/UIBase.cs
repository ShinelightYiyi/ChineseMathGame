using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class UIType
{
    private string name;
    private string path;

    public string Name { get=> name;}
    public string Path { get=> path;}

    public UIType(string uiName, string uiPath)
    {
        name = uiName;
        path = uiPath;
    }
}


public class BasePanel
{
    public UIType uiType;
    public GameObject activeObject;

    public BasePanel(UIType uitype) 
    { 
        uiType = uitype;
    }

    public virtual void OnStart() 
    { 
        UIMethod.Instance.GetSpecificComponent<CanvasGroup>(activeObject).interactable = true;
    }

    public virtual void OnEnable()
    {
        UIMethod.Instance.GetSpecificComponent<CanvasGroup>(activeObject).interactable = true;
    }

    public virtual void OnDisable() 
    {
        UIMethod.Instance.GetSpecificComponent<CanvasGroup>(activeObject).interactable = false;
    }

    public virtual void OnDestroy() 
    {
        UIMethod.Instance.GetSpecificComponent<CanvasGroup>(activeObject).interactable = false;
    }


}  



public class UIMethod
{
    private static UIMethod instance;
    public static UIMethod Instance { get => instance ?? (instance = new UIMethod()); }


    /// <summary>
    /// 获得场景中的Canvas
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject go= GameObject.FindGameObjectWithTag("Canvas");
        if (go == null)
        {
            Debug.LogWarning("获取Canvas失败");
        }
        return go;
    }


    public GameObject FindChangeCanvas()
    {
        GameObject go = GameObject.FindGameObjectWithTag("ChangeCanvas");
        GameObject.DontDestroyOnLoad(go);
        if (go == null)
        {
            Debug.LogWarning("获取Canvas失败");
        }
        return go;
    }

    /// <summary>
    /// 获取物体子物体
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
    public GameObject FindObjectInChild(GameObject panel , string childName)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (var tra in transforms)
        {
            if (tra.gameObject.name == childName)
            {
                return tra.gameObject;
            }
        }
        return null;
    }

    /// <summary>
    /// 获得物体特定组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public T GetSpecificComponent<T>(GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component != null)
        {
            return component;
        }
        else
        {
            T newComponent = go.AddComponent<T>();
          //  Debug.LogError("未找到指定组件：" + typeof(T).Name);
            return newComponent;
        }
    }


    /// <summary>
    /// 获取子物体中的特定组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="childName"></param>
    /// <param name="go"></param>
    /// <returns></returns>
    public T GetChildComponent<T>(string childName,GameObject go) where T : Component
    {
        Transform childTransform = go.transform.Find(childName);
        if (childTransform != null)
        {
            T component = childTransform.GetComponent<T>();
            if (component != null)
            {
                return component;
            }
            else
            {
                Debug.LogError("子物体中未找到指定组件：" + typeof(T).Name);
                return null;
            }
        }
        else
        {
            Debug.LogError("未找到指定名称的子物体：" + childName);
            return null;
        }
    }
}


public class UIManager
{
    private static UIManager instance;
    public static UIManager Instance { get => instance ?? (instance = new UIManager()); }

    public Dictionary<string, GameObject> uiObjectDic;

    public Stack<BasePanel> uiStack;

    public GameObject canvasObj;

    public UIManager()
    {
        uiObjectDic = new Dictionary<string, GameObject>();
        uiStack = new Stack<BasePanel>();
    }
        

    public GameObject GetSingleObject(UIType uiType)
    {
        //从本地加载物体  
        if (uiObjectDic.ContainsKey(uiType.Name))
        {
            return uiObjectDic[uiType.Name];
        }
        //检测字典中是否已存在这个物体，如果已存在，则直接返回该物体  

        if (canvasObj == null)
        {
                canvasObj = UIMethod.Instance.FindCanvas();         
        }


        //若Canvas为空，则结束函数  

        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path), canvasObj.transform);
    //从本地加载GameObject  

    return gameObject;
    }


    public void Push(BasePanel basePanel)
    {
        if (uiStack.Count > 0)
        {
            uiStack.Peek().OnDisable();
        }
        //首先检测栈中是否已有物体，如果栈中已存在物体，则让存在的物体取消 再加入最上层的物体  

        GameObject uiObject = GetSingleObject(basePanel.uiType);
    //获取UI并传入实际的物体当中

        uiObjectDic.Add(basePanel.uiType.Name, uiObject);

        basePanel.activeObject = uiObject;

        if (uiStack.Count == 0)
        {
            uiStack.Push(basePanel);
        }
        else
        {
            if (uiStack.Peek().uiType.Name != basePanel.uiType.Name)
            {
                uiStack.Push(basePanel);
            }
        }
        basePanel.OnStart();
    }


    /// <summary>
    /// 切换场景时使用
    /// </summary>
    /// <param name="basePanel"></param>
    public void PushChangeScene(BasePanel basePanel)
    {

        GameObject canvasObj = GameObject.FindGameObjectWithTag("ChangeCanvas");

        GameObject.DontDestroyOnLoad(canvasObj);

        GameObject uiObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(basePanel.uiType.Path), canvasObj.transform);

        basePanel.activeObject = uiObject;

        basePanel.OnStart();
    }

    public void Clear()
    {
        uiStack.Clear();
    }

    public void Pop(bool isLoad)
    {
        if (isLoad)
        {
            if (uiStack.Count > 0)
            {
                uiStack.Peek().OnDisable();
                uiStack.Peek().OnDestroy();
                GameObject.Destroy(uiObjectDic[uiStack.Peek().uiType.Name]);
                uiObjectDic.Remove(uiStack.Peek().uiType.Name);
                uiStack.Pop();
                Pop(true);
            }
        }
        //当isLoad为真时，推出所有ui
        else
        {
            if (uiStack.Count > 0)
            {
                uiStack.Peek().OnDisable();
                uiStack.Peek().OnDestroy();
                GameObject.Destroy(uiObjectDic[uiStack.Peek().uiType.Name]);
                uiObjectDic.Remove(uiStack.Peek().uiType.Name);
                uiStack.Pop();

                if (uiStack.Count > 0)
                {
                    uiStack.Peek().OnEnable();
                }
            }
        }
        //当isLoad为假时，只推出第一个物体  
    }
}
