using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRootText : MonoBehaviour
{
   
    void Start()
    {
        UIManager.Instance.Push(new PanelA());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
