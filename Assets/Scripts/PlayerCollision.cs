
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{

  
  
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




    }

   

    

}
