using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    private float secondsCount;
    public double interval;
    public Rigidbody rb;

    void Start()
    {
       // Instantiate(ball, transform.position, transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsCount += Time.deltaTime;
        if(secondsCount >= interval)
        {
            Instantiate(ball, transform.position, transform.rotation);
            
            secondsCount = 0;
        }
        
    }
}
