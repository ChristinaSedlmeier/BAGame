using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionnaireManager : MonoBehaviour
{
    public ToggleGroup damageToggle;
    public GameObject nextPage;
    public GameObject oldPage;

    public GameObject[] questionGroupArr;
    public QAClass07[] qaArr;
    public GameObject AnswerPanel;
    private static string[] demograficHeaders = new string[8];
    private static string[] demograficAnswers = new string[8];
    private static string[] postQuestionnaireHeaders = new string[1];
    private static string[] postQuestionnaireAnswers = new string[1];


    private void Start()
    {
        qaArr = new QAClass07[questionGroupArr.Length];
        
    }

    public void SubmitDemograficAnswerAnswer()
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
        LoadExplanation();
    }
    public void SubmitPostAnswer()
    {

        for (int i = 0; i < qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
            Debug.Log(qaArr[i].Question + " " + qaArr[i].Answer);
            postQuestionnaireHeaders[i] = questionGroupArr[i].name;
            postQuestionnaireAnswers[i] = qaArr[i].Answer;

        }
        CSVManager.SetFilePath("postQuestionnaireData", "UserData");

        CSVManager.SetHeaders(postQuestionnaireHeaders);
        CSVManager.AppendToReport(postQuestionnaireAnswers);
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

    public void LoadNextPage()
    {
        nextPage.SetActive(true);
       // oldPage.SetActive(false);
    }



}
[System.Serializable]
public class QAClass07
{
    public string Question = "";
    public string Answer = "";

}
