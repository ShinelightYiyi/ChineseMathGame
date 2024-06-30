using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleARoot : MonoBehaviour
{

    [SerializeField] GameObject[] gameObjects;


    bool canClick;

    bool one, two, three;

    bool isFinish;



    private void Start()
    {
        isFinish = false;
        canClick = true;
        one = false; two = false; three = false;

        EventCenter.Instance.AddEventListener("1被点击",()=>ChangeClick());
        EventCenter.Instance.AddEventListener("2被点击", () => ChangeClick());
        EventCenter.Instance.AddEventListener("3被点击", () => ChangeClick());
        EventCenter.Instance.AddEventListener("1被点击", () => ChangeOne());
        EventCenter.Instance.AddEventListener("2被点击", () => ChangeTwo());
        EventCenter.Instance.AddEventListener("3被点击", () => ChangeThree());

    }

    private void Update()
    {
        if (canClick)
        {
            if (one && two)
            {
                Vector2 thePosition = gameObjects[0].transform.position;
                gameObjects[0].transform.DOMove(gameObjects[1].transform.position, 0.2f);
                gameObjects[1].transform.DOMove(thePosition, 0.2f);
                EventCenter.Instance.EventTrigger("切换位置");
                
                string o = gameObjects[0].tag.ToString();
                gameObjects[0].tag = gameObjects[1].tag.ToString();
                gameObjects[1].tag = o;

                one = false;
                two = false;


            }
            if (two && three)
            {
                Vector2 thePosition = gameObjects[1].transform.position;
                gameObjects[1].transform.DOMove(gameObjects[2].transform.position, 0.2f);
                gameObjects[2].transform.DOMove(thePosition, 0.2f);
                EventCenter.Instance.EventTrigger("切换位置");

                string o = gameObjects[1].tag.ToString();
                gameObjects[1].tag = gameObjects[2].tag.ToString();
                gameObjects[2].tag = o;

                three = false;
                two = false;



            }
            if (one && three)
            {
                Vector2 thePosition = gameObjects[0].transform.position;
                gameObjects[0].transform.DOMove(gameObjects[2].transform.position, 0.2f);
                gameObjects[2].transform.DOMove(thePosition, 0.2f);
                EventCenter.Instance.EventTrigger("切换位置");

                string o = gameObjects[0].tag.ToString();
                gameObjects[0].tag = gameObjects[2].tag.ToString();
                gameObjects[2].tag = o;

                three = false;
                one = false;


            }
        }

        if (!isFinish)
        {
            if (gameObjects[0].tag == "2" && gameObjects[1].tag == "3" && gameObjects[2].tag == "1")
            {
                Debug.LogWarning("成功");
                EventCenter.Instance.Clear();
                Invoke("PushNextPanel", 0.5f);
             
                isFinish = true;
            }
        }
    }

    private void PushNextPanel()
    {
        UIManager.Instance.Push(new BookPanelB());
       // AudioMag.Instance.PlayOneShot("Audio/MainGame/MainGame_TurnPage");
    }



    private void ChangeClick()
    {
        canClick = !canClick;
    }

    private void ChangeOne()
    {
        one = !one;
    }

    private void ChangeTwo()
    {
        two = !two;
    }

    private void ChangeThree()
    {
        three = !three;
    }


}
