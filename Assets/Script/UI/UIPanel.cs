using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BookPanelB : BasePanel
{
    private static string name = "NextBookPanel";
    private static string path = "UIPanel/MainGame/NextBookPanel";

    private static UIType newUIType = new UIType(name, path);
    public BookPanelB() : base(newUIType)
    {

    }
}





public class ChangeScenePanel : BasePanel
{
    private static string name = "ChangeScenePanel";

    private static string path = "UIPanel/ChangePanel";

    private static UIType newUIType = new UIType(name,path);

    private string sceneName;
    public ChangeScenePanel(string scenename) : base(newUIType)
    {
        sceneName = scenename;
    }

    public override void OnStart()
    {
        base.OnStart();
        FadeIn();
    }

    private void FadeIn()
    {
        EventCenter.Instance.AddEventListener<float>("进度加载", (o) => FadeOut(o));
        Image image =  GameObject.FindGameObjectWithTag("ChangePanel").GetComponent<Image>();
        GameObject go = GameObject.FindGameObjectWithTag("ChangePanel");
        DG.Tweening.Sequence imageSequence = DOTween.Sequence(image);
        imageSequence.Append(image.DOFade(1f, 0.5f));
        imageSequence.OnComplete(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneController.Instance.LoadSceneAsync(sceneName);
    }

    private void FadeOut(float o)
    {
        Image image = GameObject.FindGameObjectWithTag("ChangePanel").GetComponent<Image>();
        GameObject go = GameObject.FindGameObjectWithTag("ChangePanel");
        DG.Tweening.Sequence imageSequence = DOTween.Sequence(image);
        Debug.LogWarning("淡出");
        if (o == 1)
        {
            imageSequence.Append(image.DOFade(0f, 1f));
            imageSequence.OnComplete(() => GameObject.Destroy(go));
        }
    }
}



public class AnimationPanelA : BasePanel
{
    private static string name = "AnimationPanelA";
    private static string path = "UIPanel/AnimationPanelA";

    public static UIType newUIType = new UIType(name, path);
    public AnimationPanelA() : base(newUIType)
    {

    }
}

/// <summary>
/// 游戏开始谜题
/// </summary>
public class PenPanelA : BasePanel
{
    private static string name = "PanPanelA";
    private static string path = "UIPanel/PenPanelA";
    public static UIType newUIType = new UIType(name, path);
    public PenPanelA() : base(newUIType)
    {

    }

    private void StartCanvasGroup()
    {
        GameObject go = GameObject.FindGameObjectWithTag("PenPanel");
        go.transform.DOJump(new Vector3(0, 0f, 0f), 0.5f, 1,0.2f).SetEase(Ease.OutCirc);
    }

    public override void OnStart()
    {
        base.OnStart(); 
        StartCanvasGroup();
    }

}


public class MathPanel : BasePanel
{
    private static string name = "MathPanel";
    private static string path = "UIPanel/MathPanel";

    public static UIType newUItype = new UIType(name, path);
    public MathPanel() : base(newUItype)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
    }

   
}


