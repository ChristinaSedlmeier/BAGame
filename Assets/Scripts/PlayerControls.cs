using UnityEngine.SceneManagement;
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
        Debug.Log(anim);
        if (FindObjectOfType<GameManager>().GetCondition() == "Skinny")
        {
            // Hand = HandSkinny;
        }
        else if (FindObjectOfType<GameManager>().GetCondition() == "Medium")
        {
            //Hand = HandMedium;
        }
        if (FindObjectOfType<GameManager>().GetCondition() == "Strong")
        {
            // Hand = HandStong;


        }
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("isPunching");
            anim.SetTrigger("isPunching");
            Debug.Log("is punshing ");
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            Debug.Log("is punshing animation");
           // GameObject.FindWithTag("Hand").SetActive(true);
            Hand.SetActive(true);


        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //GameObject.FindWithTag("Hand").SetActive(false);
            Hand.SetActive(false);

        }

        if(gameObject.transform.position.y <= -20)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
