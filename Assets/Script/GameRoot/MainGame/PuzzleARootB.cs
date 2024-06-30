using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using DG.Tweening;

public class PuzzleARootB : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] PlayableDirector director,directorB;
    [SerializeField] Image image;
    [SerializeField] Animator ani;
    [SerializeField] GameObject ContentA, ContentB;


    int clickIndex;
    int a, b;

    bool isFinish;

    private void Start()
    {
        clickIndex = 0;

        isFinish = false;

        EventCenter.Instance.AddEventListener<int>("点击", (o) => ChangePosition(o));

        Invoke("StartPuzzle", (float)director.duration);
    }



    private void Update()
    {
        if(!isFinish)
        {
            if ((gameObjects[0].tag == "3") && (gameObjects[1].tag == "7") && (gameObjects[2].tag == "1") && (gameObjects[3].tag == "8") && (gameObjects[4].tag == "5") && (gameObjects[5].tag == "2") && (gameObjects[6].tag == "4") && (gameObjects[7].tag == "9") && (gameObjects[8].tag == "6"))
            {
                Debug.LogWarning("完成");
                image.DOFade(1f, 0.8f).OnComplete(()=>ani.SetBool("isFinish",true));

                Invoke("PassPanel", 10f);
                isFinish = true;
            }
        }
    }

    private void PassPanel()
    {
        ContentA.SetActive(false);
        ContentB.SetActive(false);
        EventCenter.Instance.Clear();
        UIManager.Instance.Push(new BookPuzzleB());
        AudioMag.Instance.PlayOneShot("Audio/MainGame/MainGame_TurnPage");
        directorB.Play();
    }

    private void StartPuzzle()
    {
        GameObject go = GameObject.FindGameObjectWithTag("BookPanel");
        Destroy(go);
    }

    private void ChangePosition(int o)
    {
        clickIndex++;

        if(clickIndex == 1)
        {
            a = o;
        }
        if(clickIndex == 2) 
        {
            b = o;
            string tagA = gameObjects[a-1].tag;
            Vector2 thePosition = gameObjects[a-1].transform.position;

            gameObjects[a - 1].transform.DOMove(gameObjects[b-1].transform.position, 0.3f).SetEase(Ease.OutCirc);
            gameObjects[b-1].transform.DOMove(thePosition , 0.3f).SetEase (Ease.OutCirc);

            gameObjects[a - 1].tag = gameObjects[b-1].tag;
            gameObjects[b - 1].tag = tagA;
            
            clickIndex = 0;
            a = 0;
            b = 0;

            EventCenter.Instance.EventTrigger("切换位置");

        }

    }


}
