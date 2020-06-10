using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public GameObject destroyedVersion;

    public int hitCounter = 0;
    public int hitsNeeded = 0;


    private void OnTriggerStay(Collider collider)
    {

        Debug.Log("in Destory Box");
       
        if (collider.tag == "Player")
        {
            if (Input.GetKeyDown("h"))
            {
                hitCounter++;
                if (hitCounter >= hitsNeeded)
                {
                    Instantiate(destroyedVersion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    hitCounter = 0;

                }

            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        hitCounter = 0;

    }


}
