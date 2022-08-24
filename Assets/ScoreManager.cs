using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager 
{
    private static int score;
    private static int combo;
    private static float bonus;
    static ScoreManager()//�����m��񂯂�start�Ă�ł���Ȃ����畁�ʂɃR���X�g���N�^�ŏ���������
    {
        score = 0;
        combo = 0;
        bonus = 1.0f;
    }
    public static int GetScore()
    {
        return score;
    }
    public  static void Init_Score()
    {
        score = 0;
        combo = 0;
    }
    public static int GetBonus()
    {
        return combo;
    } 
    public static void AddScore(int BlockScore)
    {
        score += (int)(BlockScore*bonus);
        bonus += 0.2f;
        combo++;
        Debug.Log($"bonus:{bonus}");
    }
    public static void InitBonus()
    {
        combo = 0;
        bonus = 1.0f;
    }
    // Start is called before the first frame update
     public static void Start()
    {
    }

    
    // Update is called once per frame
    static void Update()
    {
        
    }
}
