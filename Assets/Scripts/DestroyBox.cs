using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public GameObject destroyedVersion;


    public int hitCounter = 0;
    public int hitsNeeded = 0;


    private void OnTriggerEnter(Collider collider)
    {

       
        if (collider.tag == "Hand")
        {
            Debug.Log("Box punched");

            hitCounter++;
                if (hitCounter >= hitsNeeded)
                {
                FindObjectOfType<SoundManager>().Play("WoodBreaking");
                    FindObjectOfType<LevelManager>().ActivateHitUI();
                    Instantiate(destroyedVersion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    hitCounter = 0;

                }

            
        }

    }

 

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            hitCounter = 0;


        }

    }


}
