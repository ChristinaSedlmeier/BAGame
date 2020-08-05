using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public class GameManager : MonoBehaviour

{
    private static Random rng = new Random();
    private static List<int> round = new List<int>(Enumerable.Range(2, 5));
    static public int roundCounter = 1;
    static public int level = 1;
    static public bool difficultyHard = false;
    static public string difficulty;
    static public string[] conditions =  new string[3];

    static public string[] condition1 = new string[3] { "Skinny", "Medium", "Strong" };
    static public string[] condition2 = new string[3] { "Skinny", "Strong" , "Medium" };
    static public string[] condition3 = new string[3] {  "Medium", "Strong" , "Skinny", };
    static public string[] condition4 = new string[3] {  "Medium", "Skinny", "Strong" };
    static public string[] condition5 = new string[3] { "Strong", "Skinny", "Medium", };
    static public string[] condition6 = new string[3] {"Strong", "Medium", "Skinny", };

    static public int conditionNum = 0;
    static public int score = 0;
    static public int stars = 0;
    static public int extraLifes = 2;
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

   
  
    public void UpdateScore(int levelScore)
    {
        score += levelScore;
        
        
    }

    public void UpdateLevel()
    {

        if (roundCounter >= 6)
        {

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


    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadDemografics()
    {
        SceneManager.LoadScene("DemograficQuestionnaire");
    }

    public void SetCondition()
    {
        if(CSVManager.GetUserid() == "1" || CSVManager.GetUserid() == "7" || CSVManager.GetUserid() == "13" || CSVManager.GetUserid() == "19" || CSVManager.GetUserid() == "25" || CSVManager.GetUserid() == "31" || CSVManager.GetUserid() == "37" || CSVManager.GetUserid() == "43")
        {
            conditions = condition1;
        } else if(CSVManager.GetUserid() == "2" || CSVManager.GetUserid() == "8" || CSVManager.GetUserid() == "14" || CSVManager.GetUserid() == "20" || CSVManager.GetUserid() == "26" || CSVManager.GetUserid() == "32" || CSVManager.GetUserid() == "38" || CSVManager.GetUserid() == "44")
        {
            conditions = condition2;
        }
        else if (CSVManager.GetUserid() == "3" || CSVManager.GetUserid() == "9" || CSVManager.GetUserid() == "15" || CSVManager.GetUserid() == "21" || CSVManager.GetUserid() == "27" || CSVManager.GetUserid() == "33" || CSVManager.GetUserid() == "39" || CSVManager.GetUserid() == "45")
        {
            conditions = condition3;
        }
        else if (CSVManager.GetUserid() == "4" || CSVManager.GetUserid() == "10" || CSVManager.GetUserid() == "16" || CSVManager.GetUserid() == "22" || CSVManager.GetUserid() == "28" || CSVManager.GetUserid() == "34" || CSVManager.GetUserid() == "40" || CSVManager.GetUserid() == "46")
        {
            conditions = condition4;
        }
        else if (CSVManager.GetUserid() == "5" || CSVManager.GetUserid() == "11" || CSVManager.GetUserid() == "17" || CSVManager.GetUserid() == "23" || CSVManager.GetUserid() == "29" || CSVManager.GetUserid() == "35" || CSVManager.GetUserid() == "41" || CSVManager.GetUserid() == "47")
        {
            conditions = condition5;
        }
        else if (CSVManager.GetUserid() == "7" || CSVManager.GetUserid() == "12" || CSVManager.GetUserid() == "18" || CSVManager.GetUserid() == "24" || CSVManager.GetUserid() == "30" || CSVManager.GetUserid() == "36" || CSVManager.GetUserid() == "42" || CSVManager.GetUserid() == "48")
        {
            conditions = condition6;
        }
        else
        {
            conditions = condition1;
        }
    }


    public string GetCondition()
    {
        if (conditions[0] != null)
        {
            Debug.Log("EmptyCOndition");
            return conditions[conditionNum];
        }
        else return condition6[conditionNum];
        
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
            extraLifes = 2;
        }
        
    }
    public void SetZeroExtraLifes()
    {
        extraLifes = 0;
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