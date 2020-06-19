
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool easy = true;
    public GameManager gameManager;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LevelText;

    public void LoadEasyGame()
    {
        gameManager.UpdateDifficulty(false);
        SceneManager.LoadScene("Level" + gameManager.GetLevel() + gameManager.GetDifficulty());
        //gameManager.UpdateLevel();
        // UpdateLevelUI();


    }

    public void LoadHardGame()
    {
        gameManager.UpdateDifficulty(true);
        SceneManager.LoadScene("Level" + gameManager.GetLevel() + gameManager.GetDifficulty());
        //gameManager.UpdateLevel();
        // UpdateLevelUI();

    }

    void Start()
    {
        ScoreText.text = "Score: " + gameManager.GetScore().ToString();
        LevelText.text = "Level " + gameManager.GetLevel().ToString();
    }
}
