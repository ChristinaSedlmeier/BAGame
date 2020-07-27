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
        qaArr = new QAClass07[questionGroupArr.Length];
        bodyEsteemQaArr = new QAClass07[bodyEsteemQuestionGroupArr.Length];
        for (int i = 0; i < button.Length; i++)
        {

            button[i].interactable = false;
        }

    }

    public void SubmitDemograficAnswer(GameObject nextPage)
    {
        
        for(int i = 0; i<qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
            Debug.Log(qaArr[i].Question + " " + qaArr[i].Answer);
            demograficHeaders[i] = questionGroupArr[i].name;
            demograficAnswers[i] = qaArr[i].Answer;
           
        }
        CSVManager.SetFilePath("demograficData", "UserData");

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
            Debug.Log(bodyEsteemQaArr[i].Question + " " + bodyEsteemQaArr[i].Answer);
            bodyEsteemHeaders[i] = bodyEsteemQaArr[i].Question;
            bodyEsteemAnswers[i] = bodyEsteemQaArr[i].Answer;

        }
        CSVManager.SetFilePath("bodyEsteemData", "UserData");

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
        int length = qaArr.Length;
        if(pageCounter== 1)
        {
            length = 5;
        }
        if(pageCounter == 2)
        {
            j = 6;
            length = qaArr.Length;
            buttonCounter = 1;
        }
        for (int i = j ; i < length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
            if (qaArr[i].Answer != "")
            {
                filled = true;
            } else
            {
                filled = false;
                break;
            }
            

        }
        if(filled == true)
        {
            
            button[buttonCounter].interactable = true;
            pageCounter++;
            filled = false;

        }
    }


}
[System.Serializable]
public class QAClass07
{
    public string Question = "";
    public string Answer = "";

}
