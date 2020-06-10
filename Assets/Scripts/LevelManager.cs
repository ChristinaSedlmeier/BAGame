using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    bool levelCompleted = false;
    public float restartDelay = 1f;
    public Text ScoreText;
    public Transform player;
    public int levelScore = 0;
    static public int extraLifes;
    public Text extraLifeText;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    

    public GameManager gameManager;


    void Start()
    {
        UpdateExtraLifes();
    }
    public void CompleteLevel()
    {
        levelCompleted = true;
        completeLevelUI.SetActive(true);
        gameManager.UpdateLevel();
        gameManager.UpdateScore(levelScore);
        
    }

    public void EndGame ()
    {
        if(gameHasEnded == false && levelCompleted == false)
        {
            gameHasEnded = true;
            gameOverUI.SetActive(true);
            gameManager.UpdateLevel();
            gameManager.UpdateScore(levelScore);
            levelCompleted = false;

            //Invoke("Restart", restartDelay);

        }
       
    }

    private void Update()
    {
       
        if(player.position.y < 2.5)
        {
            

            //EndGame();
            // CompleteLevel();

            if (gameManager.difficultyHard == false)
            {
                gameManager.increaseExtraLifes();
                if(gameManager.GetExtraLifes() >= 0)
                {
                    Time.timeScale = 0;
                    Restart();
                }
                else
                {
                     EndGame();
                }

            }
            else
            {
                
                 EndGame();

            }
                      
        }
    }

    void Restart ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void updateScore()
    {
        levelScore += 10;
        ScoreText.text = levelScore.ToString();
        

    }

    public void UpdateExtraLifes()
    {
        extraLifeText.text = gameManager.GetExtraLifes().ToString();

    }
}
 
