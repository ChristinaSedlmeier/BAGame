using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;
using Random = System.Random;

public class GameManager : MonoBehaviour

{
    private static Random rng = new Random();
    private static List<int> round = new List<int>(Enumerable.Range(2, 5));
    static public int roundCounter = 1;
    static public int level = 1;
    static public bool difficultyHard;
    static public string difficulty;
    static public string[] conditions = new string[3] { "Skinny", "Medium", "Strong" };
    static public int conditionNum = 0;
    static public int score = 0;
    static public int stars = 0;
    static public int extraLifes = 3;
    static public string side;
    private static string[] headers = new string[8]
  {
        "condition",
        "level",
        "difficulty",
        "damage",
        "score",
        "levelCompleted",
        "lostCoins",
        "extraLifes",
  };

    // static int currentHealth= 3;
    //static string levelCompleted;




    private void Start()
    {
       
        
    }

    public void UpdateCSVFile(int damage, int levelScore, bool levelCompleted, int lostCoins)
    {
        CSVManager.SetFilePath((GetCondition() + "_RiskBehaviour"), "LevelData");
        CSVManager.SetHeaders(headers);

        CSVManager.AppendToReport(new string[8]
        {
            GetCondition(),
            GetLevel().ToString(),
            GetDifficulty(),
            damage.ToString(),
            levelScore.ToString(),
            levelCompleted.ToString(),
            lostCoins.ToString(),
            GetExtraLifes().ToString(),

        }) ;
    }

    public void UpdateSideCSVFile()
    {
        CSVManager.SetFilePath("SideDecision", "LevelData/SideDecision");
        CSVManager.SetHeaders(new string[3]{ 
            "condition",
            "level",
            "side" 
        });
        CSVManager.AppendToReport(new string[3] {
            GetCondition(),
            GetLevel().ToString(),
            GetSide()
        }); ;
    }
  
    public void UpdateScore(int levelScore)
    {
        score += levelScore;
        
        
    }

    public void UpdateLevel()
    {

        if (roundCounter >= 6)
        {

            UpdateSideCSVFile();
            //FindObjectOfType<SoundManager>().Stop();
            SceneManager.LoadScene("PostQuestionnaire");
        }
        else
        {
            level++;
            roundCounter++;
            LoadMenu();
        }
        
    }

    public void UpdateDifficulty(bool difficult)
    {
        difficultyHard = difficult;
    }

    public void ShuffleRounds()
    {
        round.Shuffle();
        Debug.Log(roundCounter.ToString() + "is rounds");
        Debug.Log(round[0] + "+" + round[1] + "+" + round[2] + "+" + round[3]);
    }

    public int GetLevel()
    {
        if(roundCounter == 1)
        {
            
           
            return 1;
        }
        else
        {
            return round[roundCounter-2];
        }

    }
    public int GetRound()
    {
        return roundCounter;
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
        return (roundCounter-1) * 25;
    }

    public double GetScoreStars()
    {
        Debug.Log(score);
        return score * 0.01;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
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
        roundCounter = 1;
        round.Shuffle();
        score = 0;
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
    public void SetZeroExtraLifes()
    {
        extraLifes = 0;
    }
 
    public void SetSideDecision(bool left)
    {
        if(left == true)
        {
            side = "left";
        } else
        {
            side = "right";
        }
    }

    private string GetSide()
    {
        return side;
    }

    public void ShuffleList()
    {
        round.Shuffle();
    }
    

}

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}