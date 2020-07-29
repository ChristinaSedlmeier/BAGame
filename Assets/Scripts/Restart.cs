using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text lifes;
    public Text morLifes;
    public void Deactivate()
    {
        Debug.Log("Deactivate");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    private void Start()
    {
        lifes.text = FindObjectOfType<GameManager>().GetExtraLifes().ToString();
        if (FindObjectOfType<GameManager>().GetExtraLifes() == 1)
        {
            morLifes.text = "more life";
        }
        else
        {
            morLifes.text = "more lifes";
        }
        FindObjectOfType<SoundManager>().Play("Fail");
        Time.timeScale = 1;
    }
}
