using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadUserID : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        //ReadCSVFile();
    }

    // Update is called once per frame
    public static string ReadCSVFile()
    {
        Debug.Log(Application.dataPath);
        StreamReader reader = new StreamReader(Application.dataPath + "/UserID/UserID.txt");
        string id = reader.ReadToEnd();
        
        reader.Close();
        return id;
    }
}
