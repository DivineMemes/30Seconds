using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour 
{
    public InputManager inputManager;

    public List<Text> textHolder;

    Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    [Serializable]
    public struct ScoreData
    {
        public string name;
        public float score;
    }

    public List<ScoreData> entries;

    private void SortScores()
    {
        entries.Sort((a, b) => a.score.CompareTo(b.score));
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + @"/"  + currentScene.name + "playerInfo.dat") == false)
        {
            file = File.Create(Application.persistentDataPath + @"/" + currentScene.name + "playerInfo.dat");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + @"/" + currentScene.name + "playerInfo.dat", FileMode.Open);
        }
        ScoreData entry = new ScoreData();
        entry.score = GetComponent<TimerScript>().timer;
        entry.name = inputManager.playerName;

        entries.Add(entry);

        SortScores();

        bf.Serialize(file, entries);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + @"/" + currentScene.name + "playerInfo.dat"))
        {
            Debug.Log(Application.persistentDataPath + @"/" + currentScene.name + "playerInfo.dat");
            FileStream file = File.Open(Application.persistentDataPath + @"/" + currentScene.name + "playerInfo.dat", FileMode.Open);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                entries = (List<ScoreData>)bf.Deserialize(file);
                //Debug.Log(entries);
            }
            catch(SerializationException e)
            {
                Debug.Log("empty" + e.Message);
                throw;
            }
            finally
            {
                file.Close();
            }


            for(int i = 0; i < entries.Count; i++)
            {
                //Debug.Log("textholder count = " + textHolder.Count + " i =" + i);
                textHolder[i].text = entries[i].name + " " + entries[i].score;
            }

        }
      
    }

}