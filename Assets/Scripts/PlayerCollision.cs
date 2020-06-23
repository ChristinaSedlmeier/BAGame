
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{

    bool isMoving = false;
    bool obstacleCollision = false;


    void OnCollisionEnter(Collision collisionInfo)
    {
       
        if (collisionInfo.collider.tag == "Coin")
        {
            
            // movement.enabled = false;
            FindObjectOfType<LevelManager>().updateScore();
            Destroy(collisionInfo.gameObject);

        }
        if (collisionInfo.collider.tag == "LeftBall")
        {

            // movement.enabled = false;
            FindObjectOfType<PlayerControls>().LeftHitAnimation();
            FindObjectOfType<LevelManager>().TakeDamage(4);
            Debug.Log("leftHit");
        }
        if (collisionInfo.collider.tag == "Obstacle")
        {

        }







    }

   

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.tag == "Obstacle" && (isMoving == true))
        {
            FindObjectOfType<PlayerControls>().StartPushAnimation();
        } else
        {
            FindObjectOfType<PlayerControls>().StopPushAnimation();
        }
       
     
        if (Input.GetKeyDown("p"))
        {
            //FindObjectOfType<PlayerControls>().StartPushAnimation();
            //Debug.Log(collision.collider.gameObject.name);
             //collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 20000);
            
        }
        if (Input.GetKeyUp("p"))
        {
            //FindObjectOfType<PlayerControls>().StopPushAnimation();
         
        }
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("bstacle hit");
           
        }
       
    

    
    }
   

    private void OnCollisionExit(Collision collision)
    {
        if (!Input.GetKeyDown("w"))
        {
        //FindObjectOfType<PlayerControls>().StopPushAnimation();
        //FindObjectOfType<PlayerControls>().StopPushAnimation();
    }
    }





}
