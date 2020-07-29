using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionnaireManager : MonoBehaviour
{

    public Button[] button;

    private static int buttonCounter = 0;
    private int pageCounter = 1;

    public GameObject[] questionGroupArr;
    public QAClass07[] qaArr;


    public GameObject[] bodyEsteemQuestionGroupArr;
    public QAClass07[] bodyEsteemQaArr;

    private static string[] demograficHeaders = new string[9];
    private static string[] demograficAnswers = new string[9];
    private static string[] bodyEsteemHeaders = new string[10];
    private static string[] bodyEsteemAnswers = new string[10];


    private static bool filled = false;





    private void Start()
    {
        Cursor.visible = true;
        qaArr = new QAClass07[questionGroupArr.Length];
        bodyEsteemQaArr = new QAClass07[bodyEsteemQuestionGroupArr.Length];
        for (int i = 0; i < button.Length; i++)
        {

           // button[i].interactable = false;
        }


        
    }

    public void SubmitDemograficAnswer(GameObject nextPage)
    {
        
        for(int i = 0; i<qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
            demograficHeaders[i] = questionGroupArr[i].name;
            demograficAnswers[i] = qaArr[i].Answer;
           
        }
        CSVManager.SetFilePath(GetCondition() + "_demograficData", "UserData/Demografics");

        CSVManager.SetHeaders(demograficHeaders);
        CSVManager.AppendToReport(demograficAnswers);
        LoadNextPage(nextPage);
        //LoadExplanation();
    }

    public void SubmitBodyEsteemAnswer()
    {

        for (int i = 0; i < bodyEsteemQaArr.Length; i++)
        {
            bodyEsteemQaArr[i] = ReadQuestionAndAnswer(bodyEsteemQuestionGroupArr[i]);
            bodyEsteemHeaders[i] = bodyEsteemQuestionGroupArr[i].name;
            bodyEsteemAnswers[i] = bodyEsteemQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_bodyEsteemData", "UserData/BodyEsteem");

        CSVManager.SetHeaders(bodyEsteemHeaders);
        CSVManager.AppendToReport(bodyEsteemAnswers);
        LoadExplanation();
    }


    QAClass07 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass07 result = new QAClass07();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;

       if(a.GetComponent<ToggleGroup>() != null)
        {
            for(int i = 0; i< a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break; 
                }
            }

        }
       else if(a.GetComponent<InputField>() != null)
        {
            result.Answer = a.transform.Find("Text").GetComponent<Text>().text;
        }

        return result;

    }


    public void LoadExplanation()
    {
        SceneManager.LoadScene("Explanation");
    }

    public void LoadNextPage(GameObject nextPage)
    {
        nextPage.SetActive(true);
       // oldPage.SetActive(false);
    }



    private void Update()
    {
        
        int j = 0;
        int k = 0;
        int length1 = 5;
        int length2 = qaArr.Length;
        int length3 = 5;
        int length4 = bodyEsteemQaArr.Length;


        if(pageCounter == 2)
        {

            buttonCounter = 1;
        }
        if(pageCounter == 3)
        {

            buttonCounter = 2;
           
        }
        if(pageCounter == 4)
        {

            buttonCounter = 3;
           
        }
        CheckValidation(length1,j, qaArr, questionGroupArr, button[0]);
        CheckValidation(length2, 5, qaArr, questionGroupArr, button[1]);
        CheckValidation(length3, k, bodyEsteemQaArr, bodyEsteemQuestionGroupArr, button[2]);
        CheckValidation(length4, 5, bodyEsteemQaArr, bodyEsteemQuestionGroupArr, button[3]);



    }

    void CheckValidation(int length, int j, QAClass07[] qaArray, GameObject[] questionGroupArray, Button button)
    {
        int counter = 0;
        int maxLength = length -j; 
        for (int i = j; i < length; i++)
        {
            qaArray[i] = ReadQuestionAndAnswer(questionGroupArray[i]);
            if (qaArray[i].Answer != "")
            {
                counter++;
                filled = true;
            }
            if (counter >= maxLength)
            {
                button.interactable = true;
                pageCounter++;
            }
            else
            {
                button.interactable = false;
            }


        }

    }

    private string GetCondition()
    {
        return FindObjectOfType<GameManager>().GetCondition();
    }
}
[System.Serializable]
public class QAClass07
{
    public string Question = "";
    public string Answer = "";

}
