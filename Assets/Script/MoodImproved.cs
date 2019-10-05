using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditorInternal;
using Random = System.Random;

public enum GameMood
{
    Anxious,
    Panic,
    Happy,
    Angry,
    Sad,
    Mono,
    Hyper
}

public class MoodImproved : MonoBehaviour
{

    private GameMood sceneMood;
    private int testX = 5;

    //private  possibleScenes = new Dictionary<GameMood, List<int>>();

    //Dictionary<GameMood, List<int>> possibleScenes;
    private Dictionary<GameMood, List<int>> possibleScenes = new Dictionary<GameMood, List<int>>();
     
    //Variables to make the players wait a day between conversations
    public DateTime timeNow;
    public DateTime timeGoal;

    public bool timeFinished;

    //for testing just changing day with spacebar
    public DateTime debugAddTime;

    // Start is called before the first frame update
    void Start()
    {
        //Fungus.Flowchart.BroadcastFungusMessage("Anxious3");
       checkMood();
       PopulateMoods();
       GetRandomScene(sceneMood);
        

    }

    public void PopulateMoods()
    {
        
        possibleScenes.Add(GameMood.Anxious, new List<int> {0, 1, 2, 3, 4});

        possibleScenes.Add(GameMood.Panic, new List<int> {0, 1, 2, 3, 4});

        possibleScenes.Add(GameMood.Happy, new List<int> {0, 1, 2, 3, 4});
        
        possibleScenes.Add(GameMood.Angry, new List<int> {0, 1, 2, 3, 4});
        
        possibleScenes.Add(GameMood.Sad, new List<int> {0, 1, 2, 3, 4});
        
        possibleScenes.Add(GameMood.Mono, new List<int> {0, 1, 2, 3, 4});
        
        possibleScenes.Add(GameMood.Hyper, new List<int> {0, 1, 2, 3, 4});
        
        Debug.Log("populated game scenes");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ChangeDayTesting()
    {
        timeNow = timeNow.AddDays(1);
        Debug.Log(timeNow);
        checkTime();
        checkMood();
        GetRandomScene(sceneMood);
        Handheld.Vibrate();
    }

    public void checkTime()
    {
        if (timeNow >= timeGoal)
        {
            timeFinished = true;
			
        }

    }


    public bool GetRandomScene(GameMood sceneMood)
    {
        if (timeFinished == true)
        {
            timeNow = DateTime.Now;
            timeGoal = timeNow.AddDays(1);
            Debug.Log(timeNow);
            Debug.Log(timeGoal);
            
            
            if (possibleScenes[sceneMood].Count == 0)
                return false;

            var anxiousPickIndex = UnityEngine.Random.Range(0, possibleScenes[sceneMood].Count);
            var scenePicked = possibleScenes[sceneMood][anxiousPickIndex];
            possibleScenes[sceneMood].RemoveAt(anxiousPickIndex);

            var toCall = "";

            switch (sceneMood)
            {
                case GameMood.Anxious:
                    toCall += "Anxious";
                    break;
                case GameMood.Panic:
                    toCall += "Anxious";
                    break;
                case GameMood.Happy:
                    toCall += "Happy";
                    break;
                case GameMood.Angry:
                    toCall += "Hyper";
                    break;
                case GameMood.Sad:
                    toCall += "Sad";
                    break;
                case GameMood.Mono:
                    toCall += "Mono";
                    break;
                case GameMood.Hyper:
                    toCall += "Hyper";
                    break;


            }

            toCall += scenePicked;
            Debug.Log("to Call = " + toCall);
            Fungus.Flowchart.BroadcastFungusMessage(toCall);
            

            Debug.Log("Picking Random Scene has ran");

            return true;
        }
        else
        {
            return false;
        }
    }

    public void checkMood()
    {
        sceneMood = (GameMood)UnityEngine.Random.Range(0, 6);
        DebugLog.print("scene Mood " +sceneMood);
    }
}
