
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{

  
    
    public GameObject destroyedVersionType1;
    public GameObject destroyedVersionType2;
    public GameObject destroyedVersionType3;
    public int hitCounter = 0; 


    void OnCollisionEnter(Collision collisionInfo)
    {
       

        if (collisionInfo.collider.tag == "Coin")
        {
            


            // movement.enabled = false;
            FindObjectOfType<LevelManager>().updateScore();
            Destroy(collisionInfo.gameObject);

        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "WoodenCrateType1")
        {
            if (Input.GetKeyDown("h"))
            {
                Instantiate(destroyedVersionType1, transform.position, transform.rotation);
                Destroy(collisionInfo.collider.gameObject);
            }
        }
       

        if (collisionInfo.collider.tag == "WoodenCrateType2")
        {
            if (Input.GetKeyDown("h"))
            {
                hitCounter++;
                if (hitCounter >= 2)
                {
                    Instantiate(destroyedVersionType2, transform.position, transform.rotation);
                    Destroy(collisionInfo.collider.gameObject);
                    hitCounter = 0;

                }

            }
        }
        if (collisionInfo.collider.tag == "WoodenCrateType3")
        {
            if (Input.GetKeyDown("h"))
            {
                hitCounter++;
                if (hitCounter >= 3)
                {
                    Instantiate(destroyedVersionType3, transform.position, transform.rotation);
                    Destroy(collisionInfo.collider.gameObject);
                    hitCounter = 0;
                }

            }
        }
        



    }

    private void OnCollisionExit(Collision collision)
    {
        hitCounter = 0;

    }

    

}
