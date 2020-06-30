using UnityEngine;
using UnityEditor;

public static class MyTools 
{
    [MenuItem("My Tools/ Add To Report %F11")]
    static void DEV_AppendToReport()
    {
        CSVManager.AppendToReport(
            new string[6]
            {
                "skinnyJohn",
                "1",
                "hard",
                "2",
                "20",
                "true"

            }
            );
        EditorApplication.Beep();
        Debug.Log("Report added updated sucessfully");
    }
    [MenuItem("My Tools/ Reset Report %F1")]
    static void DEV_ResetReport()
    {
        CSVManager.CreateReport();
        EditorApplication.Beep();
        Debug.Log("Report has been reset");
    }
}
