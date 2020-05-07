using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;


public class Game : MonoBehaviour
{
    public static Game current;
    public static int lengthOfGame; 
    
    // Start is called before the first frame update
    void Awake()
    {
        RunLoad();
        _InitializeServices();
    }

    public void _InitializeServices()
    {
        ServiceLocator._game = this;
        ServiceLocator._flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        ServiceLocator._dialogManager = gameObject.GetComponent<DialogManager>();
        ServiceLocator._audioManager = gameObject.GetComponent<AudioManager>();
        ServiceLocator._gameState = gameObject.GetComponent<GameState>();
        ServiceLocator._dailyMessage = gameObject.GetComponent<DailyMessage>();
        ServiceLocator._messageTiming = gameObject.GetComponent<MessageTiming>();


    }

    public void RunSave()
    {
        //ServiceLocator._dailyMessage.SaveConversation();
        //ES3.Load<SaveData>("conversations", conversations); 
        //Debug.Log("Saving the game");

    }

    public void RunLoad()
    {
       // Debug.Log("Loading the game");
    }

    public void RunClear() //clears the current save file
    {
        
    }

}
