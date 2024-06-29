using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainGameRoot : MonoBehaviour
{
    [SerializeField] GameObject Book,PBook;
    [SerializeField] Image Mask;

    bool isStart;
    float timer = 0;
    private void Start()
    {

        EventCenter.Instance.AddEventListener("开始游戏", () => StartGame());
    }

    private void Update()
    {
        if(!isStart)
        {
            if (timer != 5)
            {
                timer += Time.deltaTime;
                if (timer > 3f)
                {
                    Mask.DOFade(0.6f, 0.5f);
                    timer = 5;
                }
            }
        }
    }

    private void StartGame()
    {
      //  Debug.Log("游戏开始");
      isStart = true;
        Book.transform.DOMove(PBook.transform.position, 0.5f).SetEase(Ease.OutCirc).OnComplete(()=>PushBook());
        Book.transform.DORotate(new Vector3(0,0,1.17f),0.5f).SetEase(Ease.OutCirc);
        Mask.DOFade(0.2f,0.5f);
    }

    private void PushBook()
    {
        Book.SetActive(false);
        UIManager.Instance.Push(new BookPanel());
    }



}
