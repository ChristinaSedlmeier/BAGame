
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{

    bool isMoving = false;
    



    void OnCollisionEnter(Collision collisionInfo)
    {
       
        if (collisionInfo.collider.tag == "Coin")
        {
            
            // movement.enabled = false;
            FindObjectOfType<LevelManager>().UpdateScore();
            FindObjectOfType<SoundManager>().Play("Coin");
            Destroy(collisionInfo.gameObject);

        }
        if (collisionInfo.collider.tag == "LeftBall")
        {

            // movement.enabled = false;
            // FindObjectOfType<PlayerControls>().LeftHitAnimation();
            gameObject.GetComponent<Animator>().SetTrigger("leftHit");
            FindObjectOfType<SoundManager>().Play("Hurt");
            FindObjectOfType<LevelManager>().TakeDamage(1);


        }

      

    }

    private void Update()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
            isMoving = true;
        } else 
        {
            isMoving = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.tag == "Obstacle" && (isMoving == true))
        {
            // FindObjectOfType<PlayerControls>().StartPushAnimation();
            gameObject.GetComponent<Animator>().SetBool("isPushing", true);
            collision.collider.GetComponent<Rigidbody>().mass = 5;

        } else if(collision.collider.tag == "Obstacle" && (isMoving == false))
        {
            //FindObjectOfType<PlayerControls>().StopPushAnimation();
            gameObject.GetComponent<Animator>().SetBool("isPushing", false);
            collision.collider.GetComponent<Rigidbody>().mass = 1000;
        }
        
    

    
    }
   

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            // FindObjectOfType<PlayerControls>().StopPushAnimation();
            gameObject.GetComponent<Animator>().SetBool("isPushing", false);
            collision.collider.GetComponent<Rigidbody>().mass = 1000;
        }
        
        
    
    }





}
