using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    public bool difficultyHard = false;
    public string difficulty; 
    static public int score = 0;
    static public int extraLifes;


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

    public int GetScore()
    {
        return score;
    }
}
