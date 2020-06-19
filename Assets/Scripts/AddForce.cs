using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour

{
    private float secondsCount;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 30000);
       

        // GetComponent<Rigidbody>().useGravity = true;
    }


    void Update()
    {
        secondsCount += Time.deltaTime;
        if (secondsCount >= 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }

}