using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class test02 : MonoBehaviour,IPointerClickHandler
{ 
   
    
    public bool isclick = false;
    // Start is called before the first frame update

   
    public void OnPointerClick(PointerEventData pointerEventData)
    {

        Animation();
            
    }
    public void Animation()
    {
    
            Sequence quence = DOTween.Sequence();

            Image image = GetComponent<Image>();
            quence.Append(transform.DORotate(new Vector3(0, 0, 90), 0.1f));
            quence.Join(transform.DOScale(new Vector3(0, 0, 0), 0.1f));//加入动画，和上一个Append一起执行
            quence.Append(image.DOColor(Color.blue, 0.5f));
            quence.Append(transform.DOScale(new Vector3(0, 0, 0), 0.1f).OnComplete(() => { imagechange();}));
            quence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            
            quence.AppendInterval(0);//等待

        //quence.PrependInterval(1);//预添加动画会从后往前执行，也就是后添加的先执行，在这个案例中，下面的pre会先执行
        //然后暂停一秒，在执行append内的动画
        //quence.Prepend(transform.DOScaleZ(2f, 0.2f));
        //quence.Insert(0f, transform.DOPunchScale(new Vector3(0, 0.5f, 0), 0.1f, 10, 0.1f));//插入动画

        //回调函数
        //quence.InsertCallback(5, imagechange) ;在固定时间调用
        //quence.AppendCallback(imagechange)在队列中以固定顺序调用
        //quence.PrependCallback   

        //参数设置Parameter setting
        //链式编程：transform.DOMove().Setloop()....
        //use class TweenParams，that u can add the animations to the object which u set.
        //TweenParams para = new TweenParams();
        //para.SetLoops();
        //but the first one is better!
        transform.DOMove(Vector3.one, 2).SetLoops(3, LoopType.Yoyo);
        // we can set two parameter,they are looptimes and looptype,the looptimes can set in -1-unlimited
        // and there are some types that we can set such as yoyo and restarted and soon.
        //SetAutoKill the function that we can kill the animation when it has been already used.

        //From
        //From transform the target position to current position.
        //transform.DOMoveX(5, 1).From(false);//absolute position
        //transform.DOMoveX(5, 1).From(true);//relative position.

        //delay
        //the function that can play Animation delayed
        //transform.DOMoveX(5, 1).SetDelay(3);
        //when the Event list goes on to this line ，It will be play after 3s。

        //SetSpeedBase
        //this function means the parameter based on the Speed
        //transform.DOMoveX(5, 1).SetSpeedBased(true);
        //this line means reach 5 in the x Direction at the Speed of 1；

        //SetID
        //transform.DOMoveX(5, 1).SetId("play1");
        // DOTween.Play("play1");
        //we can use this function that we can play this animation whereever we need;

        //SetRecyclable
        // transform.DOMoveX(5, 1).SetRecyclable(true);
        //that means this animation can be recycled, it can improve the storage of data; 

        //SetRelative
        // transform.DOMoveX(5, 1).SetRelative(true);
        //this functions can make the Movetypes to relative position

        //SetUpdate
        //transform.DOMoveX(5, 1).SetUpdate(UpdateType.Normal, true);
        //this functions can set whether the animation update with unity. 

        //Ease
        //transform.DOMove(Vector3.one, 2).SetEase(Ease.InOutCubic);

        //Flash
        transform.DOMove(new Vector2(2, 0), 2).SetEase(Ease.Flash,3,0);
        //闪回 flash back
    }
    public void imagechange()
    {
        Image image = GetComponent<Image>();
        string path = "image/clockblank";
        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        image.sprite = sprite;
    }

}
