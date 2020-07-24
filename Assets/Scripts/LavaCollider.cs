using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<LevelManager>().GameLost();
        }
    }
}
