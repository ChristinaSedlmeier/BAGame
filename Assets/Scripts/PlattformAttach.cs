using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformAttach : MonoBehaviour
{

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
        if (other.tag == "WoodenCrateType2" || other.tag == "WoodenCrateType3")
        {
            other.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Player.transform.parent = null;
        if (other.tag == "Player" || other.tag == "Obstacle")
        {
            other.transform.parent = null;
        }
    }
}
