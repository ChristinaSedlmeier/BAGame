using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionGroup : MonoBehaviour
{
    public ToggleGroup damageToggle;


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