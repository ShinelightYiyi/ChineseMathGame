using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ImageController : IPointBase
{
    public bool movetrue = false;
    public GameObject[] m_Desk;
    public GameObject[] m_Desk2;
    public GameObject[] m_Desk3;
    private void Start()
    {
        m_Desk = GameObject.FindGameObjectsWithTag("images");
        m_Desk2 = GameObject.FindGameObjectsWithTag("images2");
        m_Desk3 = GameObject.FindGameObjectsWithTag("images3");
    }
    private void Update()
    {
        imageAnimation();
    }
    public override void Click()
    {
        base.Click();
        
    }

    public void imageAnimation()
    {
     
    }
    public void Eventtrigger()
    {
        EventCenter.Instance.EventTrigger("bingo");
        Debug.Log("bingo");

    }
    public void ScaleAnimation(GameObject desk)
    {
          Sequence quence = DOTween.Sequence();
          quence.Append(desk.transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }
}

