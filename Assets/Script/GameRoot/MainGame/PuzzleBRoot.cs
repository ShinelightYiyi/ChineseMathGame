using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PuzzleBRoot : MonoBehaviour
{
    [SerializeField] Animator maskAni;
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Animator Book;

    int clickIndex;
    int a, b;
    public int finishStep;
    bool isLight;
    bool isFinish;
    
    private void Start()
    {
        finishStep = 0;
        isFinish = false;
        clickIndex = 0;
        isLight = true;
        EventCenter.Instance.AddEventListener("ÇÐ»»ÖçÒ¹", () => ChangeLight());
        EventCenter.Instance.AddEventListener<int>("µã»÷", (o) => ButtonDown(o));
        EventCenter.Instance.AddEventListener<int>("µã»÷", (o) => TextA1(o));
        EventCenter.Instance.AddEventListener<int>("µã»÷",(o)=>TextA2(o));
        EventCenter.Instance.AddEventListener<int>("µã»÷", (o) => TextA3(o));

        Invoke("DestroyNextPanel", 0.5f);
    }

    private void DestroyNextPanel()
    {
        GameObject go = GameObject.FindGameObjectWithTag("NextPanel");
        Destroy(go);
    }

    private void Update()
    {
        if(!isFinish)
        {
            if(finishStep == 3)
            {
                Debug.LogWarning("³É¹¦");
                EventCenter.Instance.Clear();
                
                Invoke("NextStage", 0.5f);
                isFinish = true;    
            }
        }
    }

    private void NextStage()
    {
        Book.SetBool("canTurn", true);
        UIManager.Instance.Push(new BookPanelC());
        AudioMag.Instance.PlayOneShot("Audio/MainGame/MainGame_TurnPage");
    }

    private void TextA1(int o)
    {
        if ( ((gameObjects[0].tag == "1" && gameObjects[5].tag == "9") || (gameObjects[0].tag == "9" && gameObjects[5].tag == "1")) && ((gameObjects[0].name == "a1" && gameObjects[5].name == "b1") || (gameObjects[0].name == "b1" && gameObjects[5].name == "a1")))
        {
            finishStep++;
            Image image1 = gameObjects[0].GetComponent<Image>();
            Image image2 = gameObjects[5].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget =false;

            gameObjects[0].tag = "×ó";
        }
        else if( ((gameObjects[0].tag == "2" && gameObjects[5].tag == "8") || (gameObjects[0].tag == "8" && gameObjects[5].tag == "2")) && ((gameObjects[0].name == "a1" && gameObjects[5].name == "b1") || (gameObjects[0].name == "b1" && gameObjects[5].name == "a1")) )
        {
            finishStep++;
            Image image1 = gameObjects[0].GetComponent<Image>();
            Image image2 = gameObjects[5].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[0].tag = "×ó";
        }
        else if(((gameObjects[0].tag == "3" && gameObjects[5].tag == "7") || (gameObjects[0].tag == "7" && gameObjects[5].tag == "3")) && ((gameObjects[0].name == "a1" && gameObjects[5].name == "b1") || (gameObjects[0].name == "b1" && gameObjects[5].name == "a1")))
        {
            finishStep++;
            Image image1 = gameObjects[0].GetComponent<Image>();
            Image image2 = gameObjects[5].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[0].tag = "×ó";
        }
        else if (((gameObjects[0].tag == "4" && gameObjects[5].tag == "6") || (gameObjects[0].tag == "6" && gameObjects[5].tag == "4")) && ((gameObjects[0].name == "a1" && gameObjects[5].name == "b1") || (gameObjects[0].name == "b1" && gameObjects[5].name == "a1")))
        {
            finishStep++;
            Image image1 = gameObjects[0].GetComponent<Image>();
            Image image2 = gameObjects[5].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[0].tag = "×ó";
        }
    }

    private void TextA2(int o)
    {
        if (((gameObjects[2].tag == "1" && gameObjects[3].tag == "9") || (gameObjects[2].tag == "9" && gameObjects[3].tag == "1")) && ((gameObjects[2].name == "a2" && gameObjects[3].name == "b2") || (gameObjects[2].name == "b2" && gameObjects[3].name == "a2")))
        {
            finishStep++;
            Image image1 = gameObjects[2].GetComponent<Image>();
            Image image2 = gameObjects[3].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[2].tag ="×ó";
        }
        else if (((gameObjects[2].tag == "2" && gameObjects[3].tag == "8") || (gameObjects[2].tag == "8" && gameObjects[3].tag == "2")) && ((gameObjects[2].name == "a2" && gameObjects[3].name == "b2") || (gameObjects[2].name == "b2" && gameObjects[3].name == "a2")))
        {
            finishStep++;
            Image image1 = gameObjects[2].GetComponent<Image>();
            Image image2 = gameObjects[3].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;
            gameObjects[2].tag = "×ó";
        }
        else if (((gameObjects[2].tag == "3" && gameObjects[3].tag == "7") || (gameObjects[2].tag == "7" && gameObjects[3].tag == "3")) && ((gameObjects[2].name == "a2" && gameObjects[3].name == "b2") || (gameObjects[2].name == "b2" && gameObjects[3].name == "a2")))
        {
            finishStep++;
            Image image1 = gameObjects[2].GetComponent<Image>();
            Image image2 = gameObjects[3].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;
            gameObjects[2].tag = "×ó";
        }
        else if (((gameObjects[2].tag == "4" && gameObjects[3].tag == "6") || (gameObjects[2].tag == "6" && gameObjects[3].tag == "4")) && ((gameObjects[2].name == "a2" && gameObjects[3].name == "b2") || (gameObjects[2].name == "b2" && gameObjects[3].name == "a2")))
        {
            finishStep++;
            Image image1 = gameObjects[2].GetComponent<Image>();
            Image image2 = gameObjects[3].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;
            gameObjects[2].tag = "×ó";
        }
    }

    private void TextA3(int o)
    {

        if (((gameObjects[1].tag == "1" && gameObjects[8].tag == "9") || (gameObjects[1].tag == "9" && gameObjects[8].tag == "1")) && ((gameObjects[1].name == "a3" && gameObjects[8].name == "b3") || (gameObjects[1].name == "b3" && gameObjects[8].name == "a3")))
        {
            finishStep++;
            Image image1 = gameObjects[1].GetComponent<Image>();
            Image image2 = gameObjects[8].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[1].tag = "×ó";
        }
        else if (((gameObjects[1].tag == "2" && gameObjects[8].tag == "8") || (gameObjects[1].tag == "8" && gameObjects[8].tag == "2")) && ((gameObjects[1].name == "a3" && gameObjects[8].name == "b3") || (gameObjects[1].name == "b3" && gameObjects[8].name == "a3")))
        {
            finishStep++;
            Image image1 = gameObjects[1].GetComponent<Image>();
            Image image2 = gameObjects[8].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[1].tag = "×ó";
        }
        else if (((gameObjects[1].tag == "3" && gameObjects[8].tag == "7") || (gameObjects[1].tag == "7" && gameObjects[8].tag == "3")) && ((gameObjects[1].name == "a3" && gameObjects[8].name == "b3") || (gameObjects[1].name == "b3" && gameObjects[8].name == "a3")))
        {
            finishStep++;
            Image image1 = gameObjects[1].GetComponent<Image>();
            Image image2 = gameObjects[8].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[1].tag = "×ó";
        }
        else if (((gameObjects[1].tag == "4" && gameObjects[8].tag == "6") || (gameObjects[1].tag == "6" && gameObjects[8].tag == "4")) && ((gameObjects[1].name == "a3" && gameObjects[8].name == "b3") || (gameObjects[1].name == "b3" && gameObjects[8].name == "a3")))
        {
            finishStep++;
            Image image1 = gameObjects[1].GetComponent<Image>();
            Image image2 = gameObjects[8].GetComponent<Image>();

            image1.raycastTarget = false;
            image2.raycastTarget = false;

            gameObjects[1].tag = "×ó";
        }

    }

    private void ButtonDown(int o)
    {
        clickIndex++;
        if(clickIndex == 1)
        {
            a = o-1;
        }
        else if(clickIndex == 2)
        {
            b = o-1;
            Vector3 thePosition = gameObjects[a].transform.position;
            gameObjects[a].transform.DOMove(gameObjects[b].transform.position,0.5f);
            gameObjects[b].transform.DOMove(thePosition, 0.5f);

            string tagName = gameObjects[a].tag;
            gameObjects[a].tag = gameObjects[b].tag;
            gameObjects[b].tag = tagName;

            clickIndex = 0;
        }
    }


    private void ChangeLight()
    {
        clickIndex = 0;
        a = 0;
        b = 0;
        GameObject go = GameObject.FindGameObjectWithTag("Mask");
        Image image = go.GetComponent<Image>();
        if (isLight)
        {
            image.DOFade(0.7f, 0.5f);
            maskAni.SetBool("changeLight", true);
            isLight = false;
        }
        else if(!isLight)
        {
            image.DOFade(0f, 0.5f);
            maskAni.SetBool("changeLight", false);
            isLight = true;
        }
       
    }

    
}
