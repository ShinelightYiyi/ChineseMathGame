using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class StartGameRoot : MonoBehaviour
{
    private int line21, line31;
    private int line32, line23, line33;
    [SerializeField] CanvasGroup EmptyGroup;
    [Header("第一组")] 
    [SerializeField]    
    GameObject Line1;
    [SerializeField]
    Animator TheSecond;
    [SerializeField]
    Animator TheThird;
    [Header("第二组")]
    [SerializeField] GameObject Line2,Line2Mask;
    [SerializeField] GameObject TheSecond1,TheThird1;
    [Header("第三组")]
    [SerializeField] GameObject Line3,A32,A23,A33;
    [SerializeField] GameObject Mask3,Mask2;

    private void Start()
    {
        line21 = 1;
        line31 = 1;
        line32 = 1;
        line23 = 1;
        line33 = 1;
       StartCoroutine(ControlLine1());
        Debug.Log(Line1.transform.position);
        EventCenter.Instance.AddEventListener<int>("21",(o)=>Line2Bool(o));
        EventCenter.Instance.AddEventListener<int>("31",(o)=>Line2Int(o));
        EventCenter.Instance.AddEventListener<int>("32",(o)=>Line32(o));
        EventCenter.Instance.AddEventListener<int>("33", (o) => Line33(o));
        EventCenter.Instance.AddEventListener<int>("23", (o) => Line23(o));
    }

    private void Update()
    {
        ControlLine3();
    }


    private IEnumerator ControlLine1()
    {
        TheSecond.SetBool("ToFamily",true);
        yield return new WaitForSeconds(1.5f);
        TheThird.SetBool("ToFamily", true);
        yield return new WaitForSeconds(0.5f);
        TheThird.SetBool("ToStudy", true);
        yield return new WaitForSeconds(0.5f);
        Line1.transform.DOMove(new Vector3(0, 2.61f, 0), 0.2f).SetEase(Ease.OutQuad);
        Invoke("ControlLine2", 0.3f);
    }

    private void ControlLine2()
    {
        DG.Tweening.Sequence sequence1 = DOTween.Sequence(TheSecond1);
        sequence1.Append(TheSecond1.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
        sequence1.Append(TheSecond1.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));

        DG.Tweening.Sequence sequence2 = DOTween.Sequence(TheThird1);
        sequence2.Append(TheThird1.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
        sequence2.Append(TheThird1.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
    }

    private void ControlLine3()
    {
        if((line21 == 2 && line31 == 3)||(line21 == 3 && line31 == 2))
        {
            Line2Mask.SetActive(true);
            DG.Tweening.Sequence sequence1 = DOTween.Sequence(A33);
            sequence1.Append(A33.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
            sequence1.Append(A33.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));

            DG.Tweening.Sequence sequence2 = DOTween.Sequence(A32);
            sequence2.Append(A32.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
            sequence2.Append(A32.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));

            DG.Tweening.Sequence sequence3 = DOTween.Sequence(A23);
            sequence2.Append(A23.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
            sequence2.Append(A23.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
            line21 = 0;
        }

        if( (line31 == 2 && line32 == 3 && line33 ==1) || (line31 == 3 && line32 == 2 && line33 == 1) || (line31 == 3 && line32 == 1 && line33 == 2) )
        {
            Mask3.SetActive(true);
            line31 = 0;
        }

        if( (line23 == 1 && line33 == 2) || (line23 == 2 && line33 == 1))
        {
            Mask2.SetActive(true);
            line23 = 0;
        }

        if(line21 == 0 && line31 == 0 && line23 == 0)
        {
            EmptyGroup.DOFade(0, 1f);
        }
        
    }

    #region
    private void Line2Bool(int o )
    {
        line21 = o;
    }

    private void Line2Int(int o )
    {
        line31 = o;
        Debug.Log("line31=" + o);
    }
    
    private void Line32(int o )
    {
        line32 = o;
        Debug.Log("line32=" + o);
    }

    private void Line23(int o )
    {
        line23 = o;
        Debug.Log("line23=" + o);
    }

    private void Line33(int o )
    {
        line33 = o;
        Debug.Log("line33=" + o);
    }

    #endregion



}
