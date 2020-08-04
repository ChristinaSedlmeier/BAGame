using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject nextCanvas;

    private void Start()
    {
        
        
    }

    public void Destroy()
    {
       nextCanvas.SetActive(true);
        Destroy(gameObject);
    }

    public void PlayWin()
    {
        FindObjectOfType<SoundManager>().Play("Win");
        scoreText.text = "You collected " + FindObjectOfType<GameManager>().GetScore().ToString() + " Coins";
    }
}
