using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionnaireManager : MonoBehaviour
{
    public ToggleGroup damageToggle;
    public GameObject nextPage;
    public GameObject oldPage;

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

    public void LoadExplanation()
    {
        SceneManager.LoadScene("Explanation");
    }

    public void LoadNextPage()
    {
        nextPage.SetActive(true);
       // oldPage.SetActive(false);
    }


}
