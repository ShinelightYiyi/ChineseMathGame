using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ImageController : PointBase
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
       Sequence quence = DOTween.Sequence();
        if (change.isclick == 1)
        {
            foreach (GameObject desk2 in m_Desk2)
            {
                ScaleAnimation(desk2);
            }
        }
        else if (change.isclick == 2)
        {
            foreach (GameObject desk3 in m_Desk3)
            {
                ScaleAnimation(desk3);
            }
        }

        foreach (GameObject desk in m_Desk)
        {

            ScaleAnimation(desk);
            
            if (change.isclick == 1)
            {
                quence.Append(desk.transform.DOLocalMoveY(130,0.05f));
                
                
            }
          
        }
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

