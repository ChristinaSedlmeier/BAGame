using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDCanvas : MonoBehaviour
{
    public GameObject WASDUI;
    public GameObject boxCollider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DestoryObject();
        }
        
    }

    public void DestoryObject()
    {
        Destroy(boxCollider);
        Destroy(WASDUI);

    }

    private void Start()
    {
        if (FindObjectOfType<GameManager>().GetLevel() == 1)
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
}
