using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    //bool levelCompleted = false;
    public float restartDelay = 1f;

    public int levelScore = 0;
    public int maxHealth = 3;
    public int currentHealth = 0;
    private int currentDamage = 0;
    public bool levelCompleted;

    public TextMeshProUGUI ScoreText;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject hurtUI;
    public GameObject hitUI;


    public string perceivedDamage;

    public HealthBar healthBar;
    

    public GameManager gameManager;
    public Transform player;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
  

    public void EndGame ()
    {
        if(levelCompleted == false)
        {
            //levelCompleted = false;
            
            levelScore = 0;
            SaveLevelData(false);

        }
        if(levelCompleted == true)
        {
            completeLevelUI.SetActive(true);
            SaveLevelData(true);
        }

        Debug.Log("Level has score: " + levelScore);
        gameManager.UpdateLevel();
        Debug.Log(perceivedDamage);
        SceneManager.LoadScene("Menu");

    }

    private void SaveLevelData(bool levelCompleted)
    {
        gameManager.UpdateScore(levelScore);

        gameManager.UpdateCSVFile(currentDamage, levelScore, levelCompleted, perceivedDamage);

        
        currentDamage = 0;
    }

    private void Update()
    {

        if (player.position.y < 2.5)
        {
            if (gameManager.GetHardDifficulty() == false)
            {
                Time.timeScale = 0;
                Restart();              
            }

            else
            {
                
                levelCompleted = false;
                gameOverUI.SetActive(true);
            }
        }
        
    
                      
        
    }

    void Restart ()
    {
        Time.timeScale = 1;
        SaveLevelData(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void UpdateScore()
    {
        levelScore += 10;
        ScoreText.text = levelScore.ToString();
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("took damamge");
        hurtUI.SetActive(true);
        currentDamage += damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            if (gameManager.GetHardDifficulty() == false)
            {
                Time.timeScale = 0;
                Restart();
            }
            else {

                levelCompleted = false;
                gameOverUI.SetActive(true);
                //EndGame();
            }
        }
    }

    public void ActivateHitUI()
    {
        hitUI.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1; 
    }

    public void LoadQuestionnaire()
    {

    }

   
}
 
