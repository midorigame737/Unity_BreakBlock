using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    // 別のプログラムから参照したいためpublic
    //publicの場合SerializeFieldをつけなくてもInspectorから設定できる
    
    public int life;
}
