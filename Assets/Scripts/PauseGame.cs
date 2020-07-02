using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour


{
    public GameObject pauseUI;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Pause Game");
            FindObjectOfType<LevelManager>().PauseGame();
            pauseUI.SetActive(true);
        }
    }

    public void Continue(GameObject pauseUI)
    {
        Debug.Log("Button clicked");
        pauseUI.SetActive(false);
        FindObjectOfType<LevelManager>().ContinueGame();



    }

    public void DestroyObject(GameObject pauseTrigger)
    {
        Destroy(pauseTrigger);
    }
}
