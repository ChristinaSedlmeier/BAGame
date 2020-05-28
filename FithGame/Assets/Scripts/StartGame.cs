using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{


    private void Start()
    {
        Debug.Log("in Start game");
        
    }
    public void LoadGame()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    
    
    }
