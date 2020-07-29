using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject questionnaireUI;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        Debug.Log(FindObjectOfType<LevelManager>().GetScore());
       
    }
    public void LoadQuestionnaire()
    {
        Debug.Log("load questionnaire");

        questionnaireUI.SetActive(true);
        gameObject.SetActive(false);
 
    //SceneManager.LoadScene("Menu");
}

    public void LoadNextLevel()
    {
        FindObjectOfType<LevelManager>().EndGame();
        //SceneManager.LoadScene("Menu" + FindObjectOfType<GameManager>().GetCondition());
    }

    public void PlayFail()
    {
       if( FindObjectOfType<LevelManager>().levelCompleted == true)
        {
            FindObjectOfType<SoundManager>().Play("Win");
            ScoreText.text = "x " + FindObjectOfType<LevelManager>().GetScore().ToString();
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Fail");
            ScoreText.text = "x 0";
        }
        
    }
   
}
