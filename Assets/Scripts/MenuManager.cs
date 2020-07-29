
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

    public GameObject WASDUI;
    public GameObject boxCollider;


    public GameObject maleSkinny;
    public GameObject maleMedium;
    public GameObject maleStong;


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
        SceneManager.LoadScene(FindObjectOfType<GameManager>().GetLevel() + FindObjectOfType<GameManager>().GetDifficulty());

        FindObjectOfType<GameManager>().SetExtraLifes();
    }

    private void LoadHardGame()
    {
        //FindObjectOfType<GameManager>().UpdateDifficulty(true);
        SceneManager.LoadScene(FindObjectOfType<GameManager>().GetLevel() + FindObjectOfType<GameManager>().GetDifficulty());
 
    }

    void Start()
    {
        Cursor.visible = false;
        ScoreText.text = "x " + FindObjectOfType<GameManager>().GetScore().ToString();
        LevelText.text = "Level " + FindObjectOfType<GameManager>().GetRound().ToString();
        if (FindObjectOfType<GameManager>().GetRound() == 1)
        {
            FindObjectOfType<GameManager>().ShuffleRounds();
        }
        if(FindObjectOfType<GameManager>().GetConditionNum() != 0)
        {
            WASDUI.SetActive(false);
            boxCollider.SetActive(false);

        }

        if (FindObjectOfType<GameManager>().GetCondition() == "Skinny")
        {
            maleSkinny.SetActive(true);
            maleMedium.SetActive(false);
            maleStong.SetActive(false);
        }
        else if (FindObjectOfType<GameManager>().GetCondition() == "Medium")
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

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
