using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int score;
    private GameObject blockText;
    private GameObject scoreText;
    // Start is called before the first frame update
    private void Start(){
        blockText=GameObject.Find("BlocksTxt");
        scoreText = GameObject.Find("ScoreTxt");
    }
    private int CountBlocks(){
        GameObject[] blocks;
        blocks=GameObject.FindGameObjectsWithTag("Block");
        Debug.Log(blocks.Length);
        //BlockTxt.text=$"BLOCKS:{blocks.Length}";
        return blocks.Length;
    }
    private void OnCollisionEnter(Collision collection){
        hp--;
        if (hp == 0)
        {
            Destroy(this.gameObject);
            //なんかDestroyのタイミングがうまく合わないのでDestroyが起きたときにだけカウントする
            int blockcnt = CountBlocks();
            Debug.Log(CountBlocks());
            ScoreManager.AddScore(score);
            scoreText.GetComponent<TextMeshProUGUI>().text = $"SOCRE:{ScoreManager.GetScore()}";
            blockText.GetComponent<TextMeshProUGUI>().text = $"BLOCKS:{CountBlocks()-1}";
            if (CountBlocks() == 1)
            {
                SceneManager.LoadScene("GameClear");
            };
        }   
    }
}
