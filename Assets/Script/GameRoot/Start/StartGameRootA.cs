using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Playables;

public class StartGameRootA : MonoBehaviour
{
    private bool canStart;

    private int left, right, middle;
    private bool isFinish;
    [SerializeField] GameObject audioSource; 
    #region 物体组件
    [Header("物品")]
    [SerializeField] GameObject Pen;
    [SerializeField] GameObject Paper;
    [SerializeField] GameObject Title;
    [SerializeField] GameObject leftPen;
    [SerializeField] GameObject middlePen;
    [SerializeField] GameObject rightPen;

    [Header("图片")]
    [SerializeField] Image imagePen;
    [SerializeField] Image imagePenshadow;
    [SerializeField] Image imagePaper;
    [SerializeField] Image imagePapershadow;
    [SerializeField] Image imageTitle;
    [SerializeField] Image backGroundMask;
    [SerializeField] Image imageLeftPen;
    [SerializeField] Image imageRightPen;
    [SerializeField] Image imageMiddlePen;
    [SerializeField] Image imagethePen;
    [SerializeField] Image imagethePenShadow;
    [SerializeField] Image downPen;
    [SerializeField] Image downPenShadow;


    [Header("动画")]
    [SerializeField] Animator startAni;
    [SerializeField] Animator thePenAni;
    [SerializeField] Animator thePenShadowAni;
    [SerializeField] Animator downPenAni;
    [SerializeField] Animator downPenShadowAni;

    [Header("时间轴")]
    [SerializeField] PlayableDirector director;

    #endregion

    private void Start()
    {
        left = 1;
        right = 1;
        middle = 1;
        Invoke("StartGame", 1.5f);
        DontDestroyOnLoad(audioSource);
        AudioMag.Instance.Play("Audio/MainMnue/Main_BGM");
        MonoController.Instance.AddUpdateListener(() => MoveWithMouse());
        MonoController.Instance.AddUpdateListener(() => MouseDown());
        MonoController.Instance.AddUpdateListener(()=>FinishTextA());
        MonoController.Instance.AddUpdateListener(() => StartFinishAnimation());
        EventCenter.Instance.AddEventListener<int>("左", (o) => Left(o));
        EventCenter.Instance.AddEventListener<int>("右",(o) => Right(o));
        EventCenter.Instance.AddEventListener<int>("中",(o)=>Middle(o));

        EventCenter.Instance.AddEventListener("切换场景", () => ChangeScene());
    }

    #region 开始游戏
    private void MoveWithMouse()
    {
        Pen.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.005f;
        Paper.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 0.002f;
    }

    private void StartGame()
    {
        canStart = true;
    }
    private void MouseDown()
    {
        if (canStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioMag.Instance.PlayOneShot("Audio/MainMnue/UI_Main_StartBtn");
                backGroundMask.DOFade(0.8f, 0.5f);
                startAni.SetBool("canStart", true);
                imageTitle.DOFade(0, 0.8f).SetEase(Ease.OutCirc).SetDelay(0.5f);
                imagePaper.DOFade(0, 0.3f).SetDelay(0.6f);
                imagePen.DOFade(0, 0.3f).SetDelay(0.6f);
                imagePapershadow.DOFade(0, 1f).SetDelay(0.6f);
                imagePenshadow.DOFade(0, 1f).SetDelay(0.6f);
                Invoke("StartDirector", 0.8f);
                canStart = false;
            }
        }
    }
    #endregion

    #region 游戏初演出
    private void StartDirector()
    {
        director.Play();
        Invoke("ContinueAnimation", (float)director.duration);
    }

    private void ContinueAnimation()
    {
        leftPen.SetActive(true);
        middlePen.SetActive(true);
        rightPen.SetActive(true);

        leftPen.transform.DOMoveX(0f, 0.4f).SetEase(Ease.OutCirc);
        rightPen.transform.DOMoveX(0f,0.4f).SetEase (Ease.OutCirc);
        Invoke("ConductTheAnimation", 0.3f);
    }

    private void ConductTheAnimation()
    {
        imageLeftPen.DOFade(0, 0.2f);
        imageRightPen.DOFade(0, 0.2f);
        imageMiddlePen.DOFade(0, 0.2f);
        imagethePen.DOFade(1f, 0.1f);
        imagethePenShadow.DOFade(0.5f, 0.1f);
        Invoke("ContinuePenAnimation", 0.4f);
    }

    private void ContinuePenAnimation()
    {
        thePenAni.SetBool("canMove", true);
        thePenShadowAni.SetBool("canMove", true);
        Invoke("StartText", 0.5f);
    }

    private void StartText()
    {
        UIManager.Instance.Push(new PenPanelA());
    }

    #endregion

    #region 开局教学
    private void Left(int o)
    {
        left = o;
        Debug.Log("left=" + left);
    }

    private void Right(int o)
    {
        right = o;
        Debug.Log("right=" + right);
    }

    private void Middle(int o)
    {
        middle = o;
        Debug.Log("middle=" + middle);
    }


    private void FinishTextA()
    {
        if((left == 1 && middle == 2 && right == 3)||(left == 2 && middle == 1 && right == 3) || (left == 3&& middle == 1 &&right ==2))
        {
            isFinish = true;
        }
    }

    private void StartFinishAnimation()
    {
        if(isFinish)
        {
            isFinish = false;
            left = 0;
            Invoke("P01", 0.3f);
            
        }
    }

    private void P01()
    {
        GameObject left = GameObject.FindGameObjectWithTag("left");
        GameObject middle = GameObject.FindGameObjectWithTag("middle");
        GameObject right = GameObject.FindGameObjectWithTag("right");
        left.transform.DOMoveX(0, 0.4f).SetEase(Ease.OutCirc);
        right.transform.DOMoveX(0, 0.4f).SetEase(Ease.OutCirc);
        Invoke("ContinueFinishAnimation", 0.3f);
    }
    private void ContinueFinishAnimation()
    {
        GameObject left = GameObject.FindGameObjectWithTag("left");
        GameObject middle = GameObject.FindGameObjectWithTag("middle");
        GameObject right = GameObject.FindGameObjectWithTag("right");
        Image leftImage = left.GetComponent<Image>();
        Image middleImage = middle.GetComponent<Image>();
        Image rightImage = right.GetComponent<Image>();

        downPen.DOFade(1, 0.3f);
        downPenShadow.DOFade(0.4f, 0.3f);
        leftImage.DOFade(0, 0.5f);
        middleImage.DOFade(0, 0.5f);
        rightImage.DOFade(0, 0.5f);

        Invoke("DownPenAnimation", 0.6f);
    }

    private void DownPenAnimation()
    {
        GameObject left = GameObject.FindGameObjectWithTag("left");
        GameObject middle = GameObject.FindGameObjectWithTag("middle");
        GameObject right = GameObject.FindGameObjectWithTag("right");
        left.SetActive(false);
        middle.SetActive(false);
        right.SetActive(false);
        downPenShadowAni.SetBool("canMove", true);
        downPenAni.SetBool("canMove", true);
        GameObject[] go = GameObject.FindGameObjectsWithTag("Lights");
        for(int i = 0; i <go.Length; i++)
        {
            go[i].SetActive(false);
        }
        Invoke("LastStage", 0.5f);
    }
    #endregion

    private void LastStage()
    {
        UIManager.Instance.Push(new MathPanel());
        AudioMag.Instance.PlayOneShot("Audio/MainMnue/UI_Main_Show");
        MonoController.Instance.AddUpdateListener(() => MathPaenlPassIn());
    }

    private void MathPaenlPassIn()
    {
        float timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("MathPanel");
        CanvasGroup canvas = go.GetComponent<CanvasGroup>();
        if(timer <=0.5f)
        {
            canvas.alpha += Time.deltaTime;
            timer += Time.deltaTime;
        }
        
    }


    private void ChangeScene()
    {
        MonoController.Instance.Clear();
        EventCenter.Instance.Clear();
        UIManager.Instance.Clear();
        UIManager.Instance.PushChangeScene(new ChangeScenePanel("GameScene"));
    }

}
