using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    static public bool difficultyHard;
    static public string difficulty; 
    static public int score = 0;
    private int currentLevelScore;
    static public int extraLifes;
   // static int currentHealth= 3;
    //static string levelCompleted;


    
    public void UpdateCSVFile(int damage, int levelScore, bool levelCompleted)
    {
        CSVManager.AppendToReport(new string[6]
        {
            "SkinnyJohn",
            level.ToString(),
            GetDifficulty(),
            damage.ToString(),
            levelScore.ToString(),
            levelCompleted.ToString(),

        }) ;
    }
  
    public void UpdateScore(int levelScore)
    {
        currentLevelScore = levelScore;
        score += levelScore;
        
        
    }

    public void UpdateLevel()
    {
        level++;
    }

    public void UpdateDifficulty(bool hard)
    {
        if(hard == true)
        {
            difficultyHard = true;
            difficulty = "Hard";
            extraLifes = 0;
        } else
        {
            difficultyHard = false;
            difficulty = "Easy";
            extraLifes = 1;
        }
    }

    public void increaseExtraLifes()
    {
        extraLifes--;
    }

    public int GetExtraLifes()
    {
        return extraLifes;
    }

    public int GetLevel()
    {
        return level; 
    }

    public string GetDifficulty()
    {
        return difficulty;
    }

    public bool HardDifficulty()
    {
        return difficultyHard;
    }

    public int GetScore()
    {
        return score;
    }
}
