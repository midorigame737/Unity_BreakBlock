using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private GameObject blockText;
    // Start is called before the first frame update
    private void Start(){
        blockText=GameObject.Find("BlocksTxt");
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
        }
        TextMeshProUGUI text;
        text=blockText.GetComponent<TextMeshProUGUI>();
        int blockcnt = CountBlocks();
        text.text= $"BLOCKS:{blockcnt-1}";
        if (CountBlocks()==1){
            SceneManager.LoadScene("GameClear");
        };   
    }
}
