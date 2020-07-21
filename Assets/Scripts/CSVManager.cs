using UnityEngine;
using System.IO;

public class CSVManager 
{
    private static string directoryName = "Report";
    private  static string fileName = "report.csv";
    private static string reportSeperator = ",";
    ReadUserID id = new ReadUserID();
    public static string[] headers = new string[6]
    {
        "condition",
        "level",
        "difficulty",
        "damage",
        "score",
        "levelCompleted"

    };



    private static string timeStampHeader = "time stamp";

 //region Interactions 

    public static void AppendToReport(string[] strings)
    {
        Debug.Log("Report sucessful" + directoryName);
        VerifyDirectory();
        VerifyFile();
        using(StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            finalString += GetUserid();
            for (int i =0; i < strings.Length; i++)
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
       // VerifyDirectory();

        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            finalString += "ID";
            for(int i = 0; i<headers.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeperator;
                }
                finalString += headers[i];
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

    public static void SetFilePath(string filePath, string directoryPath)
    {
        fileName = GetUserid() + filePath + ".csv";
        directoryName = ("UserData/") + directoryPath;



    }
    public static void SetHeaders(string[] headerNames)
    {
        headers = headerNames;

    }



    //region Queries
    private static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + directoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + fileName;
    }
   
    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.Millisecond.ToString();
    }

    static string GetUserid()
    {
        return ReadUserID.ReadCSVFile();
    }
}
