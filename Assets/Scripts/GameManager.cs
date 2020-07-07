using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    static public bool difficultyHard;
    static public string difficulty;
    static public string[] conditions = new string[3] { "Skinny", "Medium", "Strong" };
    static public int conditionNum = 0;
    static public int score = 0;
    static public int stars;
    private int currentLevelScore;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
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
        CSVManager.SetFilePath("levelData", "UserData");
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
        currentLevelScore = levelScore;
        score += levelScore;
        
        
    }

    public void UpdateLevel()
    {

        if (level >= 3)
        {
            Debug.Log("In post questionnaire");
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

    public double GetPossibleStars()
    {
        return (level-1) * 2.5;
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

    public void UpdateCondition()
    {
        conditionNum++; 
    }

}
