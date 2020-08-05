using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PostQuestionnaireManager : MonoBehaviour
{

    private static int pagesCounter;

    public GameObject quitUI;


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




    public GameObject[] enjoymentQuestionGroupArr;
    public QAClass07[] enjoymentQaArr;

    private static string[] enjoymentHeaders = new string[7];
    private static string[] enjoymentAnswers = new string[7];

    public GameObject[] competenceQuestionGroupArr;
    public QAClass07[] competenceQaArr;

    private static string[] competenceHeaders = new string[6];
    private static string[] competenceAnswers = new string[6];

    public GameObject[] effortQuestionGroupArr;
    public QAClass07[] effortQaArr;

    private static string[] effortHeaders = new string[5];
    private static string[] effortAnswers = new string[5];

    public GameObject[] pressureQuestionGroupArr;
    public QAClass07[] pressureQaArr;

    private static string[] pressureHeaders = new string[5];
    private static string[] pressureAnswers = new string[5];



    public GameObject[] riskQuestionGroupArr;
    public QAClass07[] riskQaArr;

    private static string[] riskHeaders = new string[3];
    private static string[] riskAnswers = new string[3];


    public Button similarityButton;
    public Button presenceButton;
    public Button identificationButton;

    public Button enjoymentButton;
    public Button competenceButton;
    public Button effortButton;
    public Button pressureButton;

    public Button riskButton;




    private void Start()
    {
        Cursor.visible = true;

        enjoymentQaArr = new QAClass07[enjoymentQuestionGroupArr.Length];
        competenceQaArr = new QAClass07[competenceQuestionGroupArr.Length];
        effortQaArr = new QAClass07[effortQuestionGroupArr.Length];
        pressureQaArr = new QAClass07[pressureQuestionGroupArr.Length];

        similarityQaArr = new QAClass07[similarityQuestionGroupArr.Length];
        presenceQaArr = new QAClass07[presenceQuestionGroupArr.Length];
        identificationQaArr = new QAClass07[identificationQuestionGroupArr.Length];
       

        riskQaArr = new QAClass07[riskQuestionGroupArr.Length];
    }

    public void SubmitIdentificationAnswer(GameObject nextPage)
    {

        for (int i = 0; i < identificationQaArr.Length; i++)
        {
            identificationQaArr[i] = ReadQuestionAndAnswer(identificationQuestionGroupArr[i]);
            identificationHeaders[i] = identificationQuestionGroupArr[i].name;
            identificationAnswers[i] = identificationQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+"_wishfulIdentification", "PostQuestionnaires/UserIdentification/WishfulIdentification");

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
        CSVManager.SetFilePath(GetCondition()+"_embodiedPresence", "PostQuestionnaires/UserIdentification/EmbodiedPresence");

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
        CSVManager.SetFilePath(GetCondition()+"_similarityIdentification", "PostQuestionnaires/UserIdentification/SimilarityIdentification");

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
        CSVManager.SetFilePath(GetCondition()+"_enjoyment", "PostQuestionnaires/IMI/Enjoyment");

        CSVManager.SetConditionHeader(enjoymentHeaders);
        CSVManager.AppendToReportCondition(enjoymentAnswers);
        LoadNextPage(nextPage);
    }
    public void SubmitCompetenceAnswer(GameObject nextPage)
    {

        for (int i = 0; i < competenceQaArr.Length; i++)
        {
            competenceQaArr[i] = ReadQuestionAndAnswer(competenceQuestionGroupArr[i]);
            competenceHeaders[i] = competenceQuestionGroupArr[i].name;
            competenceAnswers[i] = competenceQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+ "_competence", "PostQuestionnaires/IMI/Competence");
        
        CSVManager.SetConditionHeader(competenceHeaders);
        CSVManager.AppendToReportCondition(competenceAnswers);
        LoadNextPage(nextPage);
    }

  

    public void SubmitEffortAnswer(GameObject nextPage)
    {

        for (int i = 0; i < effortQaArr.Length; i++)
        {
            effortQaArr[i] = ReadQuestionAndAnswer(effortQuestionGroupArr[i]);
            effortHeaders[i] = effortQuestionGroupArr[i].name;
            effortAnswers[i] = effortQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition()+ "_effort", "PostQuestionnaires/IMI/Effort");

        CSVManager.SetConditionHeader(effortHeaders);
        CSVManager.AppendToReportCondition(effortAnswers);
        LoadNextPage(nextPage);
    }

    public void SubmitPressureAnswer()
    {

        for (int i = 0; i < pressureQaArr.Length; i++)
        {
            pressureQaArr[i] = ReadQuestionAndAnswer(pressureQuestionGroupArr[i]);
            pressureHeaders[i] = pressureQuestionGroupArr[i].name;
            pressureAnswers[i] = pressureQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition() + "_pressure", "PostQuestionnaires/IMI/Pressure");

        CSVManager.SetConditionHeader(pressureHeaders);
        CSVManager.AppendToReportCondition(pressureAnswers);
        LoadNextCondition();
    }

    public void SubmitRiskAnswer(GameObject nextPage)
    {

        for (int i = 0; i < riskQaArr.Length; i++)
        {
            riskQaArr[i] = ReadQuestionAndAnswer(riskQuestionGroupArr[i]);
            riskHeaders[i] = riskQuestionGroupArr[i].name;
            riskAnswers[i] = riskQaArr[i].Answer;

        }
        CSVManager.SetFilePath(GetCondition() + "_risk", "PostQuestionnaires/RPS/Risk");

        CSVManager.SetConditionHeader(riskHeaders);
        CSVManager.AppendToReportCondition(riskAnswers);
        LoadNextPage(nextPage);
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
        if (FindObjectOfType<GameManager>().GetConditionNum() >= 3)
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
       
        CheckValidation(competenceButton, competenceQaArr, competenceQuestionGroupArr);
        CheckValidation(effortButton, effortQaArr, effortQuestionGroupArr);
        CheckValidation(presenceButton, presenceQaArr, presenceQuestionGroupArr);
        CheckValidation(pressureButton, pressureQaArr, pressureQuestionGroupArr);
        CheckValidation(enjoymentButton, enjoymentQaArr, enjoymentQuestionGroupArr);
        CheckValidation(identificationButton, identificationQaArr, identificationQuestionGroupArr);

        CheckValidation(riskButton, riskQaArr, riskQuestionGroupArr);


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

