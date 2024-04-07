using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelA : BasePanel
{
    private  static string name = "PanelA";
    private static string path = "UIPanel/PanelA";
    public static UIType newUIType = new UIType(name,path);
    public PanelA() : base(newUIType)
    {
        
    }

    public override void OnStart()
    {
        base.OnStart();
        ChangeScene();
    }

    private void ChangeScene()
    {
        GameObject go = GameObject.FindGameObjectWithTag(name);
        Button button = UIMethod.Instance.GetSpecificComponent<Button>(UIMethod.Instance.FindObjectInChild(go, "Button"));
        button.onClick.AddListener(() => UIManager.Instance.PushChangeScene(new ChangeScenePanel("TextB")));
    }
}


public class ChangeScenePanel : BasePanel
{
    private static string name = "ChangeScenePanel";

    private static string path = "UIPanel/ChangeScenePanel";

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
        EventCenter.Instance.AddEventListener<float>("╫Ь╤х╪сть", (o) => FadeOut(o));
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
        if (o == 1)
        {
            imageSequence.Append(image.DOFade(0f, 1f));
            imageSequence.OnComplete(() => GameObject.Destroy(go));
        }
    }
}
