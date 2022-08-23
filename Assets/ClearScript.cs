using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ClearScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreTxt");
        scoreText.GetComponent<TextMeshProUGUI>().text = $"YourScore:{ScoreManager.GetScore()}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("BreakBlock");
        }
    }
}
