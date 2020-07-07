
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
        //FindObjectOfType<GameManager>().UpdateDifficulty(false);
        SceneManager.LoadScene(FindObjectOfType<GameManager>().GetLevel() + FindObjectOfType<GameManager>().GetDifficulty()+ FindObjectOfType<GameManager>().GetCondition());

    }

    private void LoadHardGame()
    {
        //FindObjectOfType<GameManager>().UpdateDifficulty(true);
        SceneManager.LoadScene("Level" + FindObjectOfType<GameManager>().GetLevel() + FindObjectOfType<GameManager>().GetDifficulty());
 
    }

    void Start()
    {
        ScoreText.text = "Stars: " + FindObjectOfType<GameManager>().GetScoreStars().ToString() + "/" + FindObjectOfType<GameManager>().GetPossibleStars().ToString();
        LevelText.text = "Level " + FindObjectOfType<GameManager>().GetLevel().ToString();
    }
}
