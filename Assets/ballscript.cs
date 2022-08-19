using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ballscript : MonoBehaviour
{
    //[SerializeField]をつけるとInspectorから値を指定できる
   /* [SerializeField]
    private TextMeshProUGUI BlockTxt;*/
    [SerializeField]
    private float spped;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    
    void Start()
    {
        //このプログラムを適用てきようしたオブジェクトからRigidbodyの設定取得
        rb=this.GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void Update()
    {
        //ボールが動いていない状態でJumpキー(デフォルトはスペース)が推される
        if(Input.GetButtonDown("Jump")&&rb.velocity==Vector3.zero){
            //右上方向に力を加える
            rb.AddForce(new Vector3(1,0,1)*spped,ForceMode.VelocityChange);
        }
    }
    private void OnCollisionEnter(Collision collision){
        //何かに衝突したら速度を1%上げる
        rb.velocity*=1.01f;
        //水平方向の動きが小さくなったら修正する
        if(Mathf.Abs(rb.velocity.x)<5){
            //直接特定方向の要素を変更することはできない
            //rb.velocity.x*=5;
            Vector3 v=rb.velocity;
            v.x+=5;
            rb.velocity=v;
        }
        //垂直方向の動きが小さくなったら修正する
        if(Mathf.Abs(rb.velocity.z)<5){
            Vector3 v=rb.velocity;
            v.z*=5;
            rb.velocity=v;
        }
        
    }
}
