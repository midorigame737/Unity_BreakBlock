using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int CountBlocks(){
        GameObject[] blocks;
        blocks=GameObject.FindGameObjectsWithTag("Block");
        Debug.Log(blocks.Length);
        //BlockTxt.text=$"BLOCKS:{blocks.Length}";
        return blocks.Length;
    }
    private void OnCollisionEnter(Collision collection){
        Destroy(this.gameObject);
        if(CountBlocks()==1){
            SceneManager.LoadScene("GameClear");
        };   
    }
}
