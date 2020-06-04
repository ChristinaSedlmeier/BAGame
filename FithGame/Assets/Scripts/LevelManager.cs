using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float secondsCount;
    bool gameHasEnded = false;
    bool levelCompleted = false;
    public float restartDelay = 1f;
    public Text ScoreText;
    public Transform player;
    public int levelScore = 0;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;

    public GameManager gameManager;

    public void CompleteLevel()
    {
        levelCompleted = true;
        completeLevelUI.SetActive(true);
        gameManager.UpdateLevel();
        gameManager.UpdateScore(levelScore);
        
    }

    void EndGame ()
    {
        if(gameHasEnded == false && levelCompleted == false)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            gameOverUI.SetActive(true);
            //Invoke("Restart", restartDelay);

        }
       
    }

    private void Update()
    {
       
        if(player.position.y < 6)
        {
            EndGame();
            

        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void updateScore()
    {
        levelScore += 10;
        ScoreText.text = levelScore.ToString();
        

    }
}
 
