using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour
{
    public float rotation;
    public float targetTime = 0.2f;
    private float counter;
    // Start is called before the first frame update

    private void Start()
    {
        counter = targetTime;
    }
    void Update()
    {
        counter -= Time.deltaTime;

        if(counter <= 0.0f)
        {
            rotation = -rotation;
            counter = targetTime;
        }
        transform.Rotate(0f, 0.0f, rotation, Space.Self);
    }
}
