using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float secondsCount;
    bool gameHasEnded = false;
    bool levelCompleted = false;
    public float restartDelay = 1f;
    public Text obstacleScoreText;
    public Transform player;
    public Text distanceScoreText;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        levelCompleted = true;
        completeLevelUI.SetActive(true);
        
    }

    void EndGame ()
    {
        if(gameHasEnded == false && levelCompleted == false)
        {
            Debug.Log("Game over");
            gameHasEnded = true;
            //Invoke("Restart", restartDelay);

        }
       
    }

    private void Update()
    {
        distanceScoreText.text = player.position.z.ToString("0");
        secondsCount += Time.deltaTime;
        if (secondsCount >= 120)
        {
            EndGame();
            Restart();
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void updateScore(int obstacleScore)
    {
        obstacleScoreText.text = obstacleScore.ToString();
        

    }
}
 
