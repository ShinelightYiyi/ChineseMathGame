using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Onimagechange : imagechange
{
   
    public void OnImageChange(Image image)
    {
        image.DOColor(Color.blue, 0.1f);
       
    }
}
