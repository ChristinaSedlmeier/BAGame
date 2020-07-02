using UnityEngine;
using System.IO;

public static class CSVManager 
{
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeperator = ",";
    private static string[] reportHeaders = new string[7]
    {
        "character name",
        "level",
        "difficulty",
        "damage",
        "score",
        "levelCompleted",
        "perceivedDamage"
    };

    private static string timeStampHeader = "time stamp";

 //region Interactions 

    public static void AppendToReport(string[] strings)
    {
        Debug.Log("Report sucessful");
        VerifyDirectory();
        VerifyFile();
        using(StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for(int i =0; i < strings.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeperator;
                }
                finalString += strings[i];
            }
            finalString += reportSeperator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }
    public static void CreateReport()
    {
        VerifyDirectory();
        
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for(int i = 0; i<reportHeaders.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeperator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeperator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }




//region Operations
    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }
    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }



//region Queries
    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
   
    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.Millisecond.ToString();
    }
}
