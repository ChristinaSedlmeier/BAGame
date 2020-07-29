using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    

    public float restartDelay = 1f;

    public int levelScore = 0;
    public int maxHealth = 3;
    public int currentHealth = 0;
    private int currentDamage = 0;
    static private int lostCoins = 0;
    public bool levelCompleted = false;
    private int extraLifes;

    public TextMeshProUGUI ScoreText;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject hurtUI;
    public GameObject hitUI;
    public GameObject RestartUI;


    public GameObject maleSkinny;
    public GameObject maleMedium;
    public GameObject maleStong;


    public string perceivedDamage;

    public HealthBar healthBar;
    

    public GameManager gameManager;

    public Transform player;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Cursor.visible = false;
        if(FindObjectOfType<GameManager>().GetCondition() == "Skinny")
        {
            maleSkinny.SetActive(true);
            maleMedium.SetActive(false);
            maleStong.SetActive(false);
        }else if (FindObjectOfType<GameManager>().GetCondition() == "Medium")
        {
            maleSkinny.SetActive(false);
            maleMedium.SetActive(true);
            maleStong.SetActive(false);
        }
        if (FindObjectOfType<GameManager>().GetCondition() == "Strong")
        {
            maleSkinny.SetActive(false);
            maleMedium.SetActive(false);
            maleStong.SetActive(true);
        }
    }
  

    public void EndGame ()
    {
        if(levelCompleted == false)
        {

            lostCoins += levelScore;
            levelScore = 0;
            FindObjectOfType<GameManager>().SetZeroExtraLifes();
            SaveLevelData(false);



        }
        if(levelCompleted == true)
        {
            // completeLevelUI.SetActive(true);
            Debug.Log("Level Completed");
            SaveLevelData(true);

        }

        Debug.Log("Level has score: " + levelScore);
        lostCoins = 0;
        gameManager.UpdateLevel();
       

    }

    private void SaveLevelData(bool levelCompleted)
    {
        gameManager.UpdateScore(levelScore);
        Debug.Log(lostCoins + "is Lostcoins in save level data");
        gameManager.UpdateCSVFile(currentDamage, levelScore, levelCompleted, lostCoins);

        
        currentDamage = 0;
    }

    private void Update()
    {

        
                              
        
    }

    public void GameLost()
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

    void Restart ()
    {
        lostCoins = levelScore;
        levelScore = 0;
        levelCompleted = false;
        FindObjectOfType<GameManager>().DecreaseExtraLifes();
        Debug.Log(FindObjectOfType<GameManager>().GetExtraLifes() + "is extarLifes");
        if (FindObjectOfType<GameManager>().GetExtraLifes() <= 0)
        {
            
            Time.timeScale = 1;
            gameOverUI.SetActive(true);
        }else
        {

            SaveLevelData(false);
            RestartUI.SetActive(true);
          
        }

        
    }

    public void UpdateScore()
    {
        levelScore += 1;
        ScoreText.text = "x "+ levelScore.ToString();
        
    }

    public void TakeDamage(int damage)
    {
        hurtUI.SetActive(true);
        currentDamage += damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GameLost();
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

    public int GetScore()
    {
        Debug.Log(levelScore);
        return levelScore;
    }

    private void FixedUpdate()
    {
        if (maleStong.transform.position.y <= 0 || maleMedium.transform.position.y <= 0 || maleSkinny.transform.position.y <= 0)
        {
            levelCompleted = false;
            gameOverUI.SetActive(true);
        }
    }


}
 
