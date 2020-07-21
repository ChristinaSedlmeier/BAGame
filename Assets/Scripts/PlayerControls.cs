using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour

    
{
    static Animator anim;
    public GameObject Hand;
    public bool isMoving;

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
            FindObjectOfType<SoundManager>().Play("Punsh");


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
        FindObjectOfType<SoundManager>().Play("Hit");
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
