using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour

    
{
    static Animator anim;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       //Hand = GameObject.FindWithTag("Hand");
        Debug.Log(Hand);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
                  anim.SetTrigger("isPunching");
           
            
        }
        if (Input.GetKeyDown("p"))
        {
            //StartPushAnimation();
        }
        if(Input.GetKeyUp("p"))
        {
            StopPushAnimation();
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            Hand.SetActive(true);

        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Hand.SetActive(false);

        }
        
    }

    public void LeftHitAnimation()
    {
        anim.SetTrigger("leftHit");
    }

    public void StartPushAnimation()
    {
        anim.SetBool("isPushing", true);
    }

    public void StopPushAnimation()
    {
        anim.SetBool("isPushing", false);
    }
}
