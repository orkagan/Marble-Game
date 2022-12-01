using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveHighScoreToFile : MonoBehaviour
{
    public void Save(HighScoreData data)
    {
        try
        {
            //convert data to JSON ofrmat
            string json = JsonUtility.ToJson(data);
            //Get a file path to save the file in
            string path = Application.dataPath + "/highscore.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.Write(json);
            writer.Close();
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }

    public HighScoreData Load()
    {
        try
        {
            //Get a file path to save the file in
            string path = Application.dataPath + "/highscore.txt";
            //The class that will read the text file
            StreamReader reader = new StreamReader(path);
            //read the whole json at once, from start to end
            string fileData = reader.ReadToEnd();
            //read the json data and store it in something usable by us
            HighScoreData data;
            data = JsonUtility.FromJson<HighScoreData>(fileData);
            //close your files
            reader.Close();
            return data;
        }
        catch(FileNotFoundException e)
        {
            Debug.Log(e);
            return new HighScoreData();
        }
    }
}
