using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    public bool difficultyHard = false;
    static public int score = 0;


    // Update is called once per frame
    void Update()
    {
       

    }

    public void UpdateScore(int levelScore)
    {
        score += levelScore;
            
    }

    public void UpdateLevel()
    {
        level++;
    }

    public int GetLevel()
    {
        return level; 
    }

    public int GetScore()
    {
        return score;
    }
}
