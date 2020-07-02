using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelComplete : MonoBehaviour
{
    public GameObject questionnaireUI;
    public ToggleGroup damageToggle;


    public void LoadQuestionnaire()
    {

        questionnaireUI.SetActive(true);
 
    //SceneManager.LoadScene("Menu");
}

    public void LoadNextLevel()
    {
       
        SceneManager.LoadScene("Menu");
    }
    public Toggle currentSelection
    {
        get { return damageToggle.ActiveToggles().FirstOrDefault(); }
    }

    public void SaveToogleAnswer()
    {

        FindObjectOfType<LevelManager>().perceivedDamage = currentSelection.name;
        Debug.Log(currentSelection.name);
        FindObjectOfType<LevelManager>().EndGame();




    }
}
