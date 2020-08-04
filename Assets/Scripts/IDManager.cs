using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IDManager : MonoBehaviour
{

    public InputField id;
    public Button button;


    private void Start()
    {
        button.interactable = false;
    }
    void Update()
    {
        id.characterValidation = InputField.CharacterValidation.Integer;
        if(id.text != "")
        {
            button.interactable = true;
        }
    }

    public void SubmitID()
    {
        CSVManager.SetIDFilePath("UserID", "UserID");
        CSVManager.AppendID(id.text);
        FindObjectOfType<GameManager>().SetCondition();
        SceneManager.LoadScene("FirstScreen");
    }



}
