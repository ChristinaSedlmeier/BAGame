using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadUserID : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in Read UserID");
        //ReadCSVFile();
    }

    // Update is called once per frame
    public static string ReadCSVFile()
    {
        Debug.Log(Application.dataPath);
        StreamReader reader = new StreamReader(Application.dataPath + "/UserID/UserID.txt");
        string id = reader.ReadLine();
        Debug.Log(id +" is ID");

        reader.Close();
        return id;
    }
}
