
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

       

    }

   

    

}
