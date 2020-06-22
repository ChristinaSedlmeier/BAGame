using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformAttach : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        //Player.transform.parent = transform;
        if(other.tag == "Player" || other.tag == "Obstacle")
        {
            other.transform.parent = transform;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WoodenCrateType2" || other.tag == "Coin")
        {
            other.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Player.transform.parent = null;
        if (other.tag == "Player" )
        {
            other.transform.parent = transform;
        }
    }
}
