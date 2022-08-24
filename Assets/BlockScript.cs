using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int score;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource musicsource;

    private GameObject blockText;
    private GameObject scoreText;
    private GameObject comboText;
    // Start is called before the first frame update
    private void Start(){
        blockText=GameObject.Find("BlocksTxt");
        scoreText = GameObject.Find("ScoreTxt");
        comboText = GameObject.Find("ComboTxt");
        musicsource = GetComponents<AudioSource>()[0];
    }
    private int CountBlocks(){
        GameObject[] blocks;
        blocks=GameObject.FindGameObjectsWithTag("Block");
        //Debug.Log(blocks.Length);
        //BlockTxt.text=$"BLOCKS:{blocks.Length}";
        return blocks.Length;
    }
    private void OnCollisionEnter(Collision collection){
        hp--;
        if (hp == 0)
        {
            int combo = ScoreManager.GetBonus();
            ScoreManager.AddScore(score);
            scoreText.GetComponent<TextMeshProUGUI>().text = $"SOCRE:{ScoreManager.GetScore()}";

            comboText.GetComponent<TextMeshProUGUI>().text = $"COMBO:{combo}";
            
            Destroy(this.gameObject);
            //�Ȃ�Destroy�̃^�C�~���O�����܂�����Ȃ��̂�Destroy���N�����Ƃ��ɂ����J�E���g����
            int blockcnt = CountBlocks();
            Debug.Log(CountBlocks());
            
            blockText.GetComponent<TextMeshProUGUI>().text = $"BLOCKS:{CountBlocks()-1}";
            if (CountBlocks() == 1)
            {
                SceneManager.LoadScene("GameClear");
            };
        }   
    }
}
