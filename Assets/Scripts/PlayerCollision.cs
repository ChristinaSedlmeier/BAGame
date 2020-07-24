
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
            FindObjectOfType<PlayerControls>().LeftHitAnimation();
            FindObjectOfType<LevelManager>().TakeDamage(1);
            FindObjectOfType<SoundManager>().Play("Hit");

        }
        if (collisionInfo.collider.tag == "Obstacle")
        {

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
            FindObjectOfType<PlayerControls>().StartPushAnimation();
            collision.collider.GetComponent<Rigidbody>().mass = 5;

        } else if(collision.collider.tag == "Obstacle" && (isMoving == false))
        {
            FindObjectOfType<PlayerControls>().StopPushAnimation();
            collision.collider.GetComponent<Rigidbody>().mass = 1000;
        }
        
    

    
    }
   

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<PlayerControls>().StopPushAnimation();
            collision.collider.GetComponent<Rigidbody>().mass = 1000;
        }
        
        
    
    }





}
