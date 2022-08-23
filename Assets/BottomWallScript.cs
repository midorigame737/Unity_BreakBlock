using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BottomWallScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lifeText;
    [SerializeField]
    private GameObject ball;
    private LifeManager lifeManager;
    // Start is called before the first frame update
    private void Start(){
        //GameObject.Find("オブジェクト名")でScene内に存在するオブジェクトの検索を行う
        //Emptyに追加したlifeManagを取得したいので、GetComponent<Screpts>
        lifeManager=GameObject.Find("scene").GetComponent<LifeManager>();
        lifeText.text=$"LIFE:{lifeManager.life}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject);
        //ballに設定したオブジェクト生成
        ScoreManager.InitBonus();
        if(lifeManager.life>0){
            Instantiate(ball);
            lifeManager.life--;
            //ザンキ表示の更新
            lifeText.text=$"LIFE:{lifeManager.life}";
        }
        else if(lifeManager.life==0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
