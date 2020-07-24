using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTrigger : MonoBehaviour
{
    public GameObject startLevelUI;
    public bool hardDoor;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            FindObjectOfType<GameManager>().UpdateDifficulty(hardDoor);
            startLevelUI.SetActive(true);
           
        }
    }
 


    
}
