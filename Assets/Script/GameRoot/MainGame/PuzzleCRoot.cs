using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using DG.Tweening;

public class PuzzleCRoot : MonoBehaviour
{
    bool isLight;
    bool isFinish;

    public  int finishIndex;
    int clickIndex;
    int a, b;

    [SerializeField] PlayableDirector director;

    [SerializeField] GameObject day, night;
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Animator aniUp,aniDown,aniLeft,aniRight;
    [SerializeField] GameObject Up, Down, Right, Left;
    [SerializeField] Animator theEnd;

    [SerializeField] GameObject otherThing, endPanel;

    int d, e, f, g, h, i, j, k;

    private void Start()
    {
        finishIndex = 0;

        int.TryParse(gameObjects[0].tag, out d);
        int.TryParse(gameObjects[1].tag, out e);
        int.TryParse(gameObjects[2].tag, out f);
        int.TryParse(gameObjects[3].tag, out g);
        int.TryParse(gameObjects[4].tag, out h);
        int.TryParse(gameObjects[5].tag, out i);
        int.TryParse(gameObjects[6].tag, out j);
        int.TryParse(gameObjects[7].tag, out k);


        Debug.LogWarning(d);
        Debug.LogWarning(e);
        Debug.LogWarning(i);

        isFinish = false;

        a = 0;
        b = 0;

        clickIndex = 0;

        isLight = true;

        EventCenter.Instance.AddEventListener("切换昼夜", () => ChangeLight());
        EventCenter.Instance.AddEventListener<int>("点击",(o)=>ChangePosition(o));

        Invoke("StartPuzzle", 0.5f);
    }


    private void StartPuzzle()
    {
        GameObject go = GameObject.FindGameObjectWithTag("BookPanel");
        Destroy(go);
    }

    private void Update()
    {
        if (!isFinish)
        {
            if(HaveSameUnitsDigit(d,e,i)) //个位数
            {
                if(d %10 == 1)
                {
                    aniLeft.SetBool("isFinish", true);
                    Left.SetActive(true);
                    d = 0;
                    finishIndex++;
                    
                }
                else if(d %10 == 3) 
                {
                    aniRight.SetBool("isFinish", true);
                    Right.SetActive(true);
                    d = 0;
                    finishIndex++;
                }
            }
            else if(HaveSameTensDigit(d,e,i)) //十位数
            {
                if (d / 10 == 1)
                {
                    aniUp.SetBool("isFinish", true);
                    Up.SetActive(true);
                    d = 0;
                    finishIndex++;

                }
                else if (d / 10 == 3)
                {
                    aniDown.SetBool("isFinish", true);
                    Down.SetActive(true);
                    d = 0;
                    finishIndex++;
                }
            }


            if(HaveSameTensDigit(d,e,k))  //十位数
            {

                if (d / 10 == 1)
                {
                    aniUp.SetBool("isFinish", true);
                    Up.SetActive(true);
                    d = 0;
                    finishIndex++;

                }
                else if (d / 10 == 3)
                {
                    aniDown.SetBool("isFinish", true);
                    Down.SetActive(true);
                    d = 0;
                    finishIndex++;
                }
            }
            else if(HaveSameUnitsDigit(d,e,k)) //个位数
            {
                if (d % 10 == 1)
                {
                    aniLeft.SetBool("isFinish", true);
                    Left.SetActive(true);
                    d = 0;
                    finishIndex++;

                }
                else if (d % 10 == 3)
                {
                    aniRight.SetBool("isFinish", true);
                    Right.SetActive(true);
                    d = 0;
                    finishIndex++;
                }
            }


            if(HaveSameTensDigit(i,g,f))  //十位数
            { 
                if(i / 10 == 1)
                {
                    aniUp.SetBool("isFinish", true);
                    Up.SetActive(true);
                    i = 0;
                    finishIndex++;
                }
                else if(i / 10 == 3)
                {
                    aniDown.SetBool("isFinish", true);
                    Down.SetActive(true);
                    i = 0;
                    finishIndex++;
                }
            }
            else if(!HaveSameUnitsDigit(i,g,f)) //个位数
            {
                if (i % 10 == 1)
                {
                    aniLeft.SetBool("isFinish", true);
                    Left.SetActive(true);
                    i = 0;
                    finishIndex++;
                }
                else if (i % 10 == 3)
                {
                    aniRight.SetBool("isFinish", true);
                    Right.SetActive(true);
                    i = 0;
                    finishIndex++;
                }
            }

            if(HaveSameUnitsDigit(f,e,k)) //个位数
            {
                Debug.Log("完成A");
                aniRight.SetBool("isFinish", true);
                Right.SetActive(true);
                finishIndex++;
                f = 0;
            }

            if(finishIndex == 3)
            {
                Debug.LogWarning("完成");
                GameObject go = GameObject.FindGameObjectWithTag("Mask");
                Image image = go.GetComponent<Image>();
                image.DOFade(0.8f, 0.5f).OnComplete(()=> theEnd.SetBool("gameOver",true));
                Invoke("EndTheGame", (float)director.duration);
                finishIndex = 0;
            }

        }
    }
    
    private void EndTheGame()
    {
      /*  GameObject go = GameObject.FindGameObjectWithTag("FinalMask");
        Image image = go.GetComponent<Image>();
        image.DOFade(0.8f, 0.8f);*/
        otherThing.SetActive(false);
        endPanel.SetActive(true);
    }


    private void ChangeLight()
    {
        if (isLight)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Mask");
            Image image = go.GetComponent<Image>();
            Image dayImage = day.GetComponent<Image>();
            Image nightImage =night.GetComponent<Image>();
            dayImage.DOFade(0, 0.5f);
            nightImage.DOFade(1, 0.5f);
            image.DOFade(0.8f, 0.5f);
            clickIndex = 0;
            a = 0;
            b = 0;
            
        }
        else if(!isLight)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Mask");
            Image image = go.GetComponent<Image>();
            Image dayImage = day.GetComponent<Image>();
            Image nightImage = night.GetComponent<Image>();
            dayImage.DOFade(1, 0.5f);
            nightImage.DOFade(0f, 0.5f);
            image.DOFade(0f, 0.5f);
        }
        isLight = !isLight;
    }


    private void ChangePosition(int o)
    {
        clickIndex++;
        if( clickIndex == 1 ) 
        {
            a = o-1;
        }
        else if( clickIndex == 2 )
        {
            b = o-1;
            
            Vector3 thePositon = gameObjects[a].transform.position;
            gameObjects[a].transform.DOMove(gameObjects[b].transform.position, 0.5f);
            gameObjects[b].transform.DOMove(thePositon, 0.5f).OnComplete(()=>ChangeNub());

            string theTag = gameObjects[a].tag;
            gameObjects[a].tag = gameObjects[b].tag;
            gameObjects[b].tag = theTag;
            a = 0;
            b = 0;
            clickIndex = 0;
        }

    }

    private void ChangeNub()
    {
        int.TryParse(gameObjects[0].tag, out d);
        int.TryParse(gameObjects[1].tag, out e);
        int.TryParse(gameObjects[2].tag, out f);
        int.TryParse(gameObjects[3].tag, out g);
        int.TryParse(gameObjects[4].tag, out h);
        int.TryParse(gameObjects[5].tag, out i);
        int.TryParse(gameObjects[6].tag, out j);
        int.TryParse(gameObjects[7].tag, out k);
    }


    /// <summary>
    /// 检测个位数是否相同
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private  bool HaveSameUnitsDigit(int a, int b, int c)
    {
        int unitsA = a % 10;
        int unitsB = b % 10;
        int unitsC = c % 10;

        return ((unitsA == unitsB) && (unitsA == unitsC) && (unitsB == unitsC));
    }


    /// <summary>
    /// 检测十位数是否相同
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private  bool HaveSameTensDigit(int a, int b, int c)
    {
        int tensA = (a / 10) % 10;
        int tensB = (b / 10) % 10;
        int tensC = (c / 10) % 10;

        return ((tensA == tensB) && (tensA == tensC) && (tensB == tensC));
    }


}
