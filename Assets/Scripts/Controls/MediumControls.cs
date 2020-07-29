using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumControls : MonoBehaviour
{
    static Animator anim;

    public GameObject Hand;

    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isPunching");
            Debug.Log("is punshing ");

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
        gameObject.GetComponent<Animator>().SetTrigger("leftHit");
        FindObjectOfType<SoundManager>().Play("Hit");
    }

    public void StartPushAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("isPushing", true);
    }

    public void StopPushAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("isPushing", false);
    }
}
