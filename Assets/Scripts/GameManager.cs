﻿using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    static public bool difficultyHard;
    static public string difficulty;
    static public string[] conditions = new string[3] { "Skinny", "Medium", "Strong" };
    static public int conditionNum = 0;
    static public int score = 0;
    static public int stars = 0;
    static public int extraLifes = 3;
    private static string[] headers = new string[6]
  {
        "condition",
        "level",
        "difficulty",
        "damage",
        "score",
        "levelCompleted"
  };

    // static int currentHealth= 3;
    //static string levelCompleted;



    public void UpdateCSVFile(int damage, int levelScore, bool levelCompleted, string perceivedDamage)
    {
        CSVManager.SetFilePath((GetCondition() + "_RiskBehaviour"), "LevelData");
        CSVManager.SetHeaders(headers);

        CSVManager.AppendToReport(new string[6]
        {
            GetCondition(),
            GetLevel().ToString(),
            GetDifficulty(),
            damage.ToString(),
            levelScore.ToString(),
            levelCompleted.ToString(),

        }) ;
    }
  
    public void UpdateScore(int levelScore)
    {
        score += levelScore;
        
        
    }

    public void UpdateLevel()
    {

        if (level >= 5)
        {
            Debug.Log("In post questionnaire");
            //FindObjectOfType<SoundManager>().Stop();
            SceneManager.LoadScene("PostQuestionnaire");
        }
        else
        {
            level++;
            LoadMenu();
        }
        
    }

    public void UpdateDifficulty(bool difficult)
    {
        difficultyHard = difficult;
    }

    public int GetLevel()
    {
        return level;
    }

    public string GetDifficulty()
    {
        if (difficultyHard == true)
        {
            return ("Hard");
        }
        else return ("Easy");
       
    }

   public bool GetHardDifficulty()
    {
        return difficultyHard;
    }

    public int GetScore()
    {
        return score;
    }

    public double GetPossibleScore()
    {
        return (level-1) * 25;
    }

    public double GetScoreStars()
    {
        Debug.Log(score);
        return score * 0.01;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu" + GetCondition());
    }

    public string GetCondition()
    {
        return conditions[conditionNum];
    }

    public int GetConditionNum()
    {
        return conditionNum;
    }

    public void UpdateCondition()
    {
        conditionNum++;
        level = 1;
        score = 0; 
    }

    public int GetStars()
    {
        int stars = 0;
        double scoreAverage = 0;
        if (score != 0)
        {
            scoreAverage = score / (level - 1);
        }
        
        if(scoreAverage< 5)
        {
            stars =  0;
        }else if(scoreAverage>=5 && scoreAverage < 10)
        {
            stars =  1;
        }
        else if (scoreAverage >= 10 && scoreAverage < 15)
        {
            stars = 2;
        }
        else if (scoreAverage >= 15)
        {
            stars = 3;
        }
        Debug.Log(stars + "stars in Game manager");
        return stars;
    }

    public int GetExtraLifes()
    {
        return extraLifes;
    }
    public void DecreaseExtraLifes()
    {
        extraLifes--;
    }

    public void SetExtraLifes()
    {
        if(difficultyHard == true)
        {
            extraLifes = 0;
        }
        else
        {
            extraLifes = 3;
        }
        
    }
 


}
