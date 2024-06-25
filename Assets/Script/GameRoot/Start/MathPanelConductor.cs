using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;

public class MathPanelConductor : MonoBehaviour
{

    [SerializeField] GameObject Paper;

    [SerializeField] GameObject nub4;
    [SerializeField] GameObject nub5;
    [SerializeField] GameObject nub6;

    [SerializeField] GameObject nub41;
    [SerializeField] GameObject nub51;
    [SerializeField] GameObject nub61;

    [SerializeField] GameObject nub2,nub8,nub42;

    [SerializeField] GameObject nub21, nub81, nub43;

    [SerializeField] Transform P4,P6,p1,p2;

    [SerializeField] Transform P7, P8, p3, p4;

    [SerializeField] PlayableDirector directorA,directorB,directorC;


    private int left4;
    private int right6;
    private int left2;
    private int right8;
    private void Start()
    {
        left4 = 0;
        right6 = 0;
        left2 = 2;
        right8 = 4;
        EventCenter.Instance.AddEventListener<int>("点击幻方",(o)=>ConductEvent(o));
    }

    private void ConductEvent(int o)
    {
        if (o == 5)
        {
            nub5.transform.DOScale(0.9f, 0.1f).OnComplete(() => FiveEvent());
            left4 = 4;
        }
        else if (o == 4)
        {
            nub4.transform.DOScale(0.9f, 0.1f).OnComplete(() => FourEvent());
            left4 = 6;
        }
        else if (o == 6)
        {
            nub6.transform.DOScale(0.9f, 0.1f).OnComplete(() => SixEvent());
        }
        else if (o == 51)
        {
            nub51.transform.DOScale(0.9f, 0.1f).OnComplete(() => FiveOneEvent());
            right6 = 4;
        }
        else if (o == 41)
        {
            nub41.transform.DOScale(0.9f, 0.1f).OnComplete(() => FourOneEvent());
            right6 = 6;
        }
        else if(o == 61)
        {
            nub61.transform.DOScale(0.9f,0.1f).OnComplete(()=>SixOneEvent());
           
        }
        else if(o == 2)
        {
            nub2.transform.DOScale(0.9f, 0.1f).OnComplete(()=>TwoEvent());
            right8 = 4;
          
        }
        else if(o == 42)
        {
            nub42.transform.DOScale(0.9f,0.1f).OnComplete(()=>ForTwoEvent());
            right8 = 8;
        }
        else if(o == 8)
        {
            nub8.transform.DOScale(0.9f,0.1f).OnComplete(()=>EightEvent());
            right8 = 2;
        }
        else if(o == 21)
        {
             nub21.transform.DOScale(0.9f,0.1f).OnComplete(()=>TwoOneEvent());
            left2 = 4;
        }
        else if(o == 43)
        {
            nub43.transform.DOScale(0.9f,0.1f).OnComplete(()=>FourThreeEvent());
            left2 = 8;
        }
        else if(o == 81)
        {
            nub81.transform.DOScale(0.9f,0.1f).OnComplete(()=>EightOneEvent());
            left2 = 2;
        }


        if (left4 + right6 == 10)
        {
            directorA.Play();
            Invoke("NextPuzzle", (float)directorA.duration + 0.3f);
            left4 = 0;
        }

        if(left2 + right8 == 10) 
        {
            Debug.Log("成功");
            directorB.Play();
            Invoke("LastPuzzle", (float)directorB.duration + 0.3f);
        }
    }

    private void NextPuzzle()
    {
        P4.transform.DOMove(p1.position, 0.5f).SetEase(Ease.OutCirc);
        P6.transform.DOMove(p2.position, 0.5f).SetEase(Ease.OutCirc);
        CanvasGroup can = P4.GetComponent<CanvasGroup>();
        CanvasGroup cano = P6.GetComponent<CanvasGroup>();
        can.interactable = false;
        cano.interactable = false;
        Invoke("TransitionPuzzle", 0.3f);
    }

    private void TransitionPuzzle()
    {
        P7.gameObject.SetActive(true);
        P7.DOScale(1f, 0.2f).SetEase(Ease.OutBounce);
        P8.gameObject.SetActive(true);
        P8.DOScale(1f,0.2f).SetEase(Ease.OutBounce);
    }

    private void LastPuzzle()
    {
        P7.transform.DOMove(p3.position , 0.5f).SetEase(Ease.OutCirc);
        P8.transform.DOMove(p4.position , 0.5f).SetEase(Ease.OutCirc);
        CanvasGroup can = P7.GetComponent<CanvasGroup>();
        CanvasGroup cano = P8.GetComponent<CanvasGroup>();
        can.interactable=false;
        cano.interactable=false;
        Invoke("ChangeScene", 0.5f);
    }

    private void ChangeScene()
    {
        Paper.SetActive(false);
        directorC.Play();
        Invoke("EventChangeScene", (float)directorC.duration);
    }

    private void EventChangeScene()
    {
        EventCenter.Instance.EventTrigger("切换场景");
    }


    #region 第一次逻辑
    private void FiveEvent()
    {
        nub5.gameObject.SetActive(false);
        nub4.gameObject.SetActive(true);
        nub4.transform.DOScale(1.3f, 0.1f);
    }

    private void FourEvent()
    {
        nub4.gameObject.SetActive(false);
        nub6.gameObject.SetActive(true);
    }

    private void SixEvent()
    {
        nub6.gameObject.SetActive(false);
        nub5.gameObject .SetActive(true);
    }


    private void FiveOneEvent()
    {
        nub51.gameObject.SetActive(false);
        nub41.gameObject.SetActive(true);
    }

    private void FourOneEvent()
    {
        nub41.gameObject.SetActive(false);
        nub61.gameObject.SetActive(true);
    }

    private void SixOneEvent()
    {
        nub61.gameObject.SetActive(false);
        nub51.gameObject .SetActive(true);
    }
    #endregion

    #region 第二次逻辑
    private void TwoEvent()
    {
        nub2.SetActive(false);
        nub42.SetActive(true);
    }

    private void ForTwoEvent()
    {
        nub42.SetActive(false);
        nub8.SetActive(true);
    }

    private void EightEvent()
    {
        nub8.SetActive(false);
        nub2.SetActive(true);
    }

    private void TwoOneEvent()
    {
        nub21.SetActive(false);
        nub43.SetActive(true);
    }

    private void FourThreeEvent()
    {
        nub43.SetActive(false);
        nub81.SetActive(true);
    }

    private void EightOneEvent() 
    {
        nub81.SetActive(false);
        nub21.SetActive(true);
    }
    #endregion




}
