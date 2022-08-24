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
    [SerializeField]
    private float ComboSppedUp;
    private Rigidbody rb;
    private int BeforeCombo, CurrentCombo;
    private const int MUSICLENMAX = 3;
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource musicsource;
    void Start()
    {
        BeforeCombo = CurrentCombo = 0;
        //このプログラムを適用てきようしたオブジェクトからRigidbodyの設定取得
        rb=this.GetComponent<Rigidbody>();
        musicsource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        CurrentCombo = ScoreManager.GetBonus();
        if (CurrentCombo - BeforeCombo > 0)
        {
            PlayComboSound(CurrentCombo);
        }
        BeforeCombo = CurrentCombo;
        //ボールが動いていない状態でJumpキー(デフォルトはスペース)が推される
        if (Input.GetButtonDown("Jump")&&rb.velocity==Vector3.zero){
            //右上方向に力を加える
            rb.AddForce(new Vector3(1,0,1)*spped,ForceMode.VelocityChange);
        }
    }
    public void PlayComboSound(int combo)
    {
        {
            Debug.Log(CurrentCombo);
            Debug.Log(BeforeCombo);
            if (combo < 4)
            {
                musicsource.clip = clips[combo - 1];
                musicsource.Play();
            }
            else
            {
                musicsource.clip = clips[MUSICLENMAX];
                musicsource.Play();
            }
        }
    }
    private void OnCollisionEnter(Collision collision){
       
        //何かに衝突したら速度を1%上げる
        rb.velocity*=1.01f+((ScoreManager.GetBonus()+1)* ComboSppedUp);
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
