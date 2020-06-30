using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    bool levelCompleted = false;
    public float restartDelay = 1f;

    public int levelScore = 0;
    static public int extraLifes;
    public int maxHealth = 3;
    public int currentHealth = 0;
    private int currentDamage = 0;

    public TextMeshProUGUI ScoreText;
    public Text extraLifeText;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;

    public HealthBar healthBar;
    

    public GameManager gameManager;
    public Transform player;


    void Start()
    {
        UpdateExtraLifes();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void CompleteLevel()
    {
        levelCompleted = true;
        completeLevelUI.SetActive(true);     
        gameManager.UpdateScore(levelScore);
        
        gameManager.UpdateCSVFile(currentDamage, levelScore, true);

       
        gameManager.UpdateLevel();

    }

    public void EndGame ()
    {
        if(gameHasEnded == false && levelCompleted == false)
        {
            
            gameHasEnded = true;
            gameOverUI.SetActive(true);
            gameManager.UpdateScore(levelScore);
            gameManager.UpdateCSVFile(currentDamage, levelScore, false);

            levelCompleted = false;
            currentDamage = 0;
            gameManager.UpdateLevel();


            //Invoke("Restart", restartDelay);

        }
       
    }

    private void Update()
    {

        if (player.position.y < 2.5)
        {
            if (gameManager.HardDifficulty() == false)
            {
                Time.timeScale = 0;
                Restart();
                // gameManager.increaseExtraLifes();
                // if(gameManager.GetExtraLifes() >= 0)
                // {
                //     Time.timeScale = 0;
                //     Restart();
                //} 
                // else
                //{
                //   EndGame();
                //   }
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

    public void TakeDamage(int damage)
    {
        currentDamage += damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            if (gameManager.HardDifficulty() == false)
            {
                Time.timeScale = 0;
                Restart();
            }
            else { 
            
                EndGame();
            }
        }
    }
        
}
 
