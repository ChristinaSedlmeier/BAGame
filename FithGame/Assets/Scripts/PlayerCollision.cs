
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{

  
    public int obstacleScore = 0;
    

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
           
        }
        if(collisionInfo.collider.tag == "Coin")
        {
            obstacleScore++;


            // movement.enabled = false;
            FindObjectOfType<GameManager>().updateScore(obstacleScore);
            Destroy(collisionInfo.gameObject);

        }
    }

}
