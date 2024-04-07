using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static SceneController instance;
    public static SceneController Instance { get => instance ?? (instance = new SceneController()); }


    /// <summary>
    /// ͬ������
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="fun"></param>
    public void LoadScene(string sceneName, UnityAction fun)
    {
        SceneManager.LoadScene(sceneName);

        fun();
    }


    /// <summary>
    /// �첽���ؽӿ�
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadSceneAsync(string sceneName)
    {
        MonoController.Instance.StartCoroutine(RealLoadSceneAsyn(sceneName));
    }

    /// <summary>
    /// �첽����
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="fun"></param>
    /// <returns></returns>
    IEnumerator RealLoadSceneAsyn(string sceneName)
    {
        float disProgress = 0f;
        float currentProgress = 0f;

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while(currentProgress < 0.9f)
        {
            currentProgress = async.progress;
            while(disProgress < currentProgress)
            {
                disProgress += 0.01f;
                EventCenter.Instance.EventTrigger<float>("���ȼ���", disProgress);
            }
            yield return currentProgress;
        }

        while(disProgress <= 1)
        {
            disProgress += 0.01f;
            EventCenter.Instance.EventTrigger<float>("���ȼ���", disProgress);
            yield return disProgress;
        }

        while(!async.isDone)
        {
            EventCenter.Instance.EventTrigger<float>("���ȼ���", 1f);
            if(disProgress >=0.9f)
            {
                async.allowSceneActivation = true;
            }

            yield return async.progress;
        }

    }
}
