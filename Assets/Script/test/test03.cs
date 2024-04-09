using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test03 : MonoBehaviour
{
    public AnimationCurve _curve;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector2(1, 2), 2).SetEase(_curve);
    }
}
