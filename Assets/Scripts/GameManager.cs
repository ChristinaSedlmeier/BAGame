using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour

{
    static public int level = 1;
    static public bool difficultyHard;
    static public string difficulty; 
    static public int score = 0;
    static public int stars;
    private int currentLevelScore;
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


    void Start()
    {
        
    }
    public void UpdateCSVFile(int damage, int levelScore, bool levelCompleted, string perceivedDamage)
    {
        CSVManager.SetFilePath("levelData", "UserData");
        CSVManager.SetHeaders(headers);

        CSVManager.AppendToReport(new string[6]
        {
            "SkinnyJohn",
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
        level++;
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
        SceneManager.LoadScene("Menu");
    }
    
}
