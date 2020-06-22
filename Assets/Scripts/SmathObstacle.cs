using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmathObstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {

      
        if (collider.tag == "Player")
        {
            FindObjectOfType<LevelManager>().EndGame();
        }

    }
    
            


}
