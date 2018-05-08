using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour 
{
    InputManager inputManager;

    public List<Text> textHolder;
    

    [Serializable]
    public struct ScoreData
    {
        public string name;
        public float score;
    }


    public List<ScoreData> entries;

    private void SortScores()
    {
        entries.Sort((a, b) => b.score.CompareTo(a.score));
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        ScoreData entry = new ScoreData();
        entry.score = GetComponent<TimerScript>().timer;
        entry.name = inputManager.name;

        entries.Add(entry);

        SortScores();

        bf.Serialize(file, entries);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            entries = (List<ScoreData>)bf.Deserialize(file);
            file.Close();

            for(int i = 0; i < textHolder.Count; i++)
            {
                textHolder[i].text = entries[i].name + " " + entries[i].score;
            }

        }
    }

}