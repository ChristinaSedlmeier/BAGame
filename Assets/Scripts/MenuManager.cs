
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool easy;
    public GameManager gameManager;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LevelText;

    public GameObject gameStartUI;

    public void LoadGame()
    {
        if (easy)
        {
            LoadEasyGame();
        }
        if (!easy)
        {
            LoadHardGame();
        }
      
    }
    private void LoadEasyGame()
    {
        gameManager.UpdateDifficulty(false);
        SceneManager.LoadScene("Level" + gameManager.GetLevel() + gameManager.GetDifficulty());

    }

    private void LoadHardGame()
    {   
        gameManager.UpdateDifficulty(true);
        SceneManager.LoadScene("Level" + gameManager.GetLevel() + gameManager.GetDifficulty());
 
    }

    void Start()
    {
        ScoreText.text = "Score: " + gameManager.GetScore().ToString();
        LevelText.text = "Level " + gameManager.GetLevel().ToString();
    }
}
