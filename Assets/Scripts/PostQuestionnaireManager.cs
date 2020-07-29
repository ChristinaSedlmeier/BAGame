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


    public GameObject[] similarityQuestionGroupArr;
    public QAClass07[] similarityQaArr;

    private static string[] similarityHeaders = new string[6];
    private static string[] similarityAnswers = new string[6];

    public GameObject[] presenceQuestionGroupArr;
    public QAClass07[] presenceQaArr;

    private static string[] presenceHeaders = new string[6];
    private static string[] presenceAnswers = new string[6];

    public GameObject[] identificationQuestionGroupArr;
    public QAClass07[] identificationQaArr;

    private static string[] identificationHeaders = new string[5];
    private static string[] identificationAnswers = new string[5];

    public Button enjoymentButton;
    public Button masteryButton;
    public Button challengeButton;
    public Button similarityButton;
    public Button presenceButton;
    public Button identificationButton;



    private void Start()
    {
        Cursor.visible = true;
        enjoymentQaArr = new QAClass07[enjoymentQuestionGroupArr.Length];
        masteryQaArr = new QAClass07[masteryQuestionGroupArr.Length];
        challengeQaArr = new QAClass07[challengeQuestionGroupArr.Length];
        similarityQaArr = new QAClass07[similarityQuestionGroupArr.Length];
        presenceQaArr = new QAClass07[presenceQuestionGroupArr.Length];
        identificationQaArr = new QAClass07[identificationQuestionGroupArr.Length];
    }

    public void SubmitIdentificationAnswer(GameObject nextPage)
    {

        for (int i = 0; i < identificationQaArr.Length; i++)
        {
            identificationQaArr[i] = ReadQuestionAndAnswer(identificationQuestionGroupArr[i]);
            identificationHeaders[i] = identificationQuestionGroupArr[i].name;
            identificationAnswers[i] = identificationQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_wishfulIdentification", "PostQuestionnaires/UserIdentification");

        CSVManager.SetConditionHeader(identificationHeaders);
        CSVManager.AppendToReportCondition(identificationAnswers);
        LoadNextPage(nextPage);

    }

    public void SubmitPresenceAnswer(GameObject nextPage)
    {

        for (int i = 0; i < presenceQaArr.Length; i++)
        {
            presenceQaArr[i] = ReadQuestionAndAnswer(presenceQuestionGroupArr[i]);
            Debug.Log(presenceQaArr[i].Question + " " + presenceQaArr[i].Answer);
            presenceHeaders[i] = presenceQuestionGroupArr[i].name;
            presenceAnswers[i] = presenceQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_embodiedPresence", "PostQuestionnaires/UserIdentification");

        CSVManager.SetConditionHeader(presenceHeaders);
        CSVManager.AppendToReportCondition(presenceAnswers);
        LoadNextPage(nextPage);
    }
    public void SubmitSimilarityAnswer(GameObject nextPage)
    {

        for (int i = 0; i < similarityQaArr.Length; i++)
        {
            similarityQaArr[i] = ReadQuestionAndAnswer(similarityQuestionGroupArr[i]);
            similarityHeaders[i] = similarityQuestionGroupArr[i].name;
            similarityAnswers[i] = similarityQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_similarityIdentification", "PostQuestionnaires/UserIdentification");

        CSVManager.SetConditionHeader(similarityHeaders);
        CSVManager.AppendToReportCondition(similarityAnswers);
        LoadNextPage(nextPage);
    }

    public void SubmitEnjoymentAnswer(GameObject nextPage)
    {

        for (int i = 0; i < enjoymentQaArr.Length; i++)
        {
            enjoymentQaArr[i] = ReadQuestionAndAnswer(enjoymentQuestionGroupArr[i]);
            enjoymentHeaders[i] = enjoymentQuestionGroupArr[i].name;
            enjoymentAnswers[i] = enjoymentQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_enjoyment", "PostQuestionnaires/PIX");

        CSVManager.SetConditionHeader(enjoymentHeaders);
        CSVManager.AppendToReportCondition(enjoymentAnswers);
        LoadNextPage(nextPage);
    }
    public void SubmitMasteryAnswer(GameObject nextPage)
    {

        for (int i = 0; i < masteryQaArr.Length; i++)
        {
            masteryQaArr[i] = ReadQuestionAndAnswer(masteryQuestionGroupArr[i]);
            masteryHeaders[i] = masteryQuestionGroupArr[i].name;
            masteryAnswers[i] = masteryQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_mastery", "PostQuestionnaires/PIX");
        
        CSVManager.SetConditionHeader(masteryHeaders);
        CSVManager.AppendToReportCondition(masteryAnswers);
        LoadNextPage(nextPage);
    }

  

    public void SubmitChallengeAnswer()
    {

        for (int i = 0; i < challengeQaArr.Length; i++)
        {
            challengeQaArr[i] = ReadQuestionAndAnswer(challengeQuestionGroupArr[i]);
            challengeHeaders[i] = challengeQuestionGroupArr[i].name;
            challengeAnswers[i] = challengeQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_challenge", "PostQuestionnaires/PIX");

        CSVManager.SetConditionHeader(challengeHeaders);
        CSVManager.AppendToReportCondition(challengeAnswers);
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
                    //result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    result.Answer = a.transform.GetChild(i).name;
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

    private void Update()
    {

        CheckValidation(similarityButton, similarityQaArr, similarityQuestionGroupArr);
       
        CheckValidation(masteryButton, masteryQaArr, masteryQuestionGroupArr);
        CheckValidation(challengeButton, challengeQaArr, challengeQuestionGroupArr);
        CheckValidation(presenceButton, presenceQaArr, presenceQuestionGroupArr);
        CheckValidation(enjoymentButton, enjoymentQaArr, enjoymentQuestionGroupArr);
        CheckValidation(identificationButton, identificationQaArr, identificationQuestionGroupArr);


    }
    private string GetCondition()
    {
        return FindObjectOfType<GameManager>().GetCondition();
    }
    void CheckValidation(Button button, QAClass07[] qaArray, GameObject[] qaGroupArr)
    {
        int counter = 0;
        for (int i = 0; i < qaGroupArr.Length; i++)
        {
            qaArray[i] = ReadQuestionAndAnswer(qaGroupArr[i]);
            if (qaArray[i].Answer != "")
            {
                counter++;
                Debug.Log("counter: " + counter);
                Debug.Log("array: " + qaArray.Length);
            }
            if (counter >= qaArray.Length)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
}

