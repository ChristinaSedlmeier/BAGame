using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelComplete : MonoBehaviour
{
    public GameObject questionnaireUI;



    public void LoadQuestionnaire()
    {
        Debug.Log("load questionnaire");

        questionnaireUI.SetActive(true);
        gameObject.SetActive(false);
 
    //SceneManager.LoadScene("Menu");
}

    public void LoadNextLevel()
    {
       // FindObjectOfType<LevelManager>().EndGame();
        SceneManager.LoadScene("Menu");
    }
   
}
