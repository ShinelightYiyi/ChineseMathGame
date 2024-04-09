using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIText : IPointBase
{
    GameObject go;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        go = this.gameObject;
    }


    #region
    public override void Enter()
    {
        base.Enter();
        BigEnter();
    }
    public override void Down()
    {
        base.Down();
       // ColorDown();
    }

    public override void Exit()
    {
        base.Exit();
        SomallExit();
    }

    public override void DownAndDrag()
    {
        base.DownAndDrag();
        GoWithMouse();
    }

    public override void EndDrag()
    {
        base.EndDrag();
        go.transform.DOMove(new Vector3(0,0,0),0.3f).SetEase(Ease.OutQuad);
    }
    #endregion

    private void ColorDown()
    {
        image.color = new Color(Random.value, Random.value, Random.value);
    }

    private void BigEnter()
    {
        go.transform.DOScale(1.1f, 0.1f);
    }

    private void SomallExit()
    {
        go.transform.DOScale(1f, 0.1f);
    }

    private void GoWithMouse()
    {
        go.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

}
