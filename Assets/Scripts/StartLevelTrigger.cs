using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTrigger : MonoBehaviour
{
    public GameObject startLevelUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            startLevelUI.SetActive(true);
        }
    }
 


    
}
