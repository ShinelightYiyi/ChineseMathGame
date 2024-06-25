using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGameRoot : MonoBehaviour
{
    [SerializeField] GameObject Book,PBook;


    private void Start()
    {
        EventCenter.Instance.AddEventListener("开始游戏", () => StartGame());
    }


    private void StartGame()
    {
      //  Debug.Log("游戏开始");
        Book.transform.DOMove(PBook.transform.position, 0.5f).SetEase(Ease.OutCirc).OnComplete(()=>PushBook());
        Book.transform.DORotate(new Vector3(0,0,1.17f),0.5f).SetEase(Ease.OutCirc);

    }

    private void PushBook()
    {
        Book.SetActive(false);
        UIManager.Instance.Push(new BookPanel());
    }



}
