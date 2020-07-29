using UnityEngine.UI;
using UnityEngine;

public class WASDCanvas : MonoBehaviour
{
    public GameObject WASDUI;
    public GameObject boxCollider;
    public GameObject[] pages;
    private int pageCounter = 0;
    public Animator ani;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextPage();
        }
        
    }

    public void DestoryObject()
    {
        Destroy(boxCollider);
        Destroy(WASDUI);

    }

    private void Start()
    {
        ani.enabled = false;
        if (FindObjectOfType<GameManager>().GetRound() == 1)
        {
            WASDUI.SetActive(true);
            boxCollider.SetActive(true);
        }
        else
        {
            WASDUI.SetActive(false);
            boxCollider.SetActive(false);
        }
    }


    public void LoadNextPage()
    {
        pageCounter++;
        if (pageCounter >= 3)
        {
            WASDUI.SetActive(false);
            //boxCollider.SetActive(false);
            ani.enabled = true;
        }
        else
        {
            pages[pageCounter].SetActive(true);
            pages[pageCounter - 1].SetActive(false);
        }

      
    }
}
