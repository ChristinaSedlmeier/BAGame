using UnityEngine.SceneManagement;
using UnityEngine;

public class SecurityGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
