
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

    public GameObject[] emptyStars;
    public GameObject[] filledStars;



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
        ScoreText.text = FindObjectOfType<GameManager>().GetScore().ToString() + "/" + FindObjectOfType<GameManager>().GetPossibleScore().ToString();
        LevelText.text = "Level " + FindObjectOfType<GameManager>().GetLevel().ToString();
        if(FindObjectOfType<GameManager>().GetStars() == 1)
        {
            emptyStars[0].SetActive(false);
            filledStars[0].SetActive(true);

        }
        if (FindObjectOfType<GameManager>().GetStars() == 2)
        {
            emptyStars[0].SetActive(false);
            filledStars[0].SetActive(true);
            emptyStars[1].SetActive(false);
            filledStars[1].SetActive(true);

        }
        if (FindObjectOfType<GameManager>().GetStars() == 3)
        {
            emptyStars[0].SetActive(false);
            filledStars[0].SetActive(true);
            emptyStars[1].SetActive(false);
            filledStars[1].SetActive(true);
            emptyStars[2].SetActive(false);
            filledStars[2].SetActive(true);

        }
    }
}
