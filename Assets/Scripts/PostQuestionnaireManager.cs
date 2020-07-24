using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PostQuestionnaireManager : MonoBehaviour
{

    private static int pagesCounter;

    public GameObject quitUI;

    public GameObject[] enjoymentQuestionGroupArr;
    public QAClass07[] enjoymentQaArr;

    private static string[] enjoymentHeaders = new string[5];
    private static string[] enjoymentAnswers = new string[5];

    public GameObject[] masteryQuestionGroupArr;
    public QAClass07[] masteryQaArr;

    private static string[] masteryHeaders = new string[5];
    private static string[] masteryAnswers = new string[5];

    public GameObject[] challengeQuestionGroupArr;
    public QAClass07[] challengeQaArr;

    private static string[] challengeHeaders = new string[4];
    private static string[] challengeAnswers = new string[4];


    public GameObject[] samQuestionGroupArr;
    public QAClass07[] samQaArr;

    private static string[] samHeaders = new string[3];
    private static string[] samAnswers = new string[3];

    private void Start()
    {
        enjoymentQaArr = new QAClass07[enjoymentQuestionGroupArr.Length];
        masteryQaArr = new QAClass07[masteryQuestionGroupArr.Length];
        challengeQaArr = new QAClass07[challengeQuestionGroupArr.Length];
        samQaArr = new QAClass07[samQuestionGroupArr.Length];
    }

    public void SubmitEnjoymentAnswer(GameObject nextPage)
    {

        for (int i = 0; i < enjoymentQaArr.Length; i++)
        {
            enjoymentQaArr[i] = ReadQuestionAndAnswer(enjoymentQuestionGroupArr[i]);
            Debug.Log(enjoymentQaArr[i].Question + " " + enjoymentQaArr[i].Answer);
            enjoymentHeaders[i] = enjoymentQaArr[i].Question;
            enjoymentAnswers[i] = enjoymentQaArr[i].Answer;

        }
        CSVManager.SetFilePath("postQuestionnaireEnjoyment", "PostQuestionnaires");

        CSVManager.SetHeaders(enjoymentHeaders);
        CSVManager.AppendToReport(enjoymentAnswers);
        LoadNextPage(nextPage);
    }
    public void SubmitMasteryAnswer(GameObject nextPage)
    {

        for (int i = 0; i < masteryQaArr.Length; i++)
        {
            masteryQaArr[i] = ReadQuestionAndAnswer(masteryQuestionGroupArr[i]);
            Debug.Log(masteryQaArr[i].Question + " " + masteryQaArr[i].Answer);
            masteryHeaders[i] = masteryQaArr[i].Question;
            masteryAnswers[i] = masteryQaArr[i].Answer;

        }
        CSVManager.SetFilePath("postQuestionnaireMastery", "PostQuestionnaires");
        
        CSVManager.SetHeaders(masteryHeaders);
        CSVManager.AppendToReport(masteryAnswers);
        LoadNextPage(nextPage);
    }

  

    public void SubmitChallengeAnswer(GameObject nextPage)
    {

        for (int i = 0; i < challengeQaArr.Length; i++)
        {
            challengeQaArr[i] = ReadQuestionAndAnswer(challengeQuestionGroupArr[i]);
            Debug.Log(challengeQaArr[i].Question + " " + challengeQaArr[i].Answer);
            challengeHeaders[i] = challengeQaArr[i].Question;
            challengeAnswers[i] = challengeQaArr[i].Answer;

        }
        CSVManager.SetFilePath("postQuestionnaireChallenge", "PostQuestionnaires");

        CSVManager.SetHeaders(challengeHeaders);
        CSVManager.AppendToReport(challengeAnswers);
        LoadNextPage(nextPage);
    }
    public void SubmitSAMAnswer()
    {

        for (int i = 0; i < samQaArr.Length; i++)
        {
            samQaArr[i] = ReadQuestionAndAnswer(samQuestionGroupArr[i]);
            Debug.Log(samQuestionGroupArr[i].name + " " + samQaArr[i].Answer);
            samHeaders[i] = samQuestionGroupArr[i].name;
            samAnswers[i] = samQaArr[i].Answer;

        }
        CSVManager.SetFilePath("postQuestionnaireSAM", "PostQuestionnaires");

        CSVManager.SetHeaders(samHeaders);
        CSVManager.AppendToReport(samAnswers);
        LoadNextCondition();

    }

    QAClass07 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass07 result = new QAClass07();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break;
                }
            }

        }
        else if (a.GetComponent<InputField>() != null)
        {
            result.Answer = a.transform.Find("Text").GetComponent<Text>().text;
        }

        return result;

    }

    public void LoadNextPage(GameObject nextPage)
    {
        nextPage.SetActive(true);
        // oldPage.SetActive(false);
    }

    public void LoadNextCondition()
    {
        FindObjectOfType<GameManager>().UpdateCondition();
        if (FindObjectOfType<GameManager>().GetConditionNum() > 2)
        {
            QuitCanvas();
        }
        else
        {
            FindObjectOfType<GameManager>().LoadMenu();
        }
        
    }

    private void QuitCanvas()
    {
        quitUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
