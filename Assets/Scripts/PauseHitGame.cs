using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHitGame : MonoBehaviour


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

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pauseUI.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<LevelManager>().ContinueGame();
        }
    }

    void Start()
    {
        if(FindObjectOfType<GameManager>().GetConditionNum() != 0 )
        {
            Destroy(gameObject);

        }
    }

    public void DestroyObject(GameObject pauseTrigger)
    {
        Destroy(pauseTrigger);
    }
}
