using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSideDecision : MonoBehaviour

    
{
    public bool left;
    private void OnTriggerEnter(Collider other)
    {
        if(left == true && other.tag == "Player")
        {
            FindObjectOfType<GameManager>().SetSideDecision(true);
        }
        if(left == false && other.tag == "Player")
        {
            FindObjectOfType<GameManager>().SetSideDecision(false);
        }
    }
}
