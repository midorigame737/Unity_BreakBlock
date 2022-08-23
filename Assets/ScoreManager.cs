using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager 
{
    private static int score;
    public static int GetScore()
    {
        return score;
    }
    public static void AddScore(int BlockScore)
    {
        score += BlockScore;
    }
    // Start is called before the first frame update
     static void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    static void Update()
    {
        
    }
}
