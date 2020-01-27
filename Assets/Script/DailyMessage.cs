using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DailyMessage : MonoBehaviour
{
    protected List<DialogManager.Dialog> conversations;
    public Block startingConversation;


    // Start is called before the first frame update
    void Start()
    {
        QueueMessage();
    }
    
    public void setFirstConversation() //sets the first conversation of the game manually if don't want it
                                       //to be random'
    {
            startingConversation = ServiceLocator._flowchart.FindBlock("HappyMessage1");
            ServiceLocator._flowchart.ExecuteBlock(startingConversation);
        
    }

    public void QueueMessage() // queue everything for the set amount of days to play (5 for starting) 
    {
        conversations = SaveLoad.myData; 
        if (conversations == null) //if conversations doesn't exist we create a list of the messages with how many days the player can play '
        {
           // SaveData myData = new SaveData()
           for (int i = 0; i < ServiceLocator._messageTiming.lengthOfGame; i++)
            {
                conversations.Add(ServiceLocator._dialogManager.LoadMessage());
            }

            SaveLoad.myData = conversations; 
            //myData.conversations = conversations; 
            Debug.Log("how many conversations loaded "+conversations.Count);
            ES3.Save<List<DialogManager.Dialog>>("conversations",conversations);
            setFirstConversation();
            return;  //drops out of function and won't continue 
        }
        else
        {
            Debug.Log("didn't queue'");
        }

        if (ServiceLocator._messageTiming.CheckTimeMet()) // make this prettier create a toString function in the DialogManager that does this for me? 
        {
            Debug.Log(conversations[ServiceLocator._messageTiming.currentDay].mood.ToString()+conversations[ServiceLocator._messageTiming.currentDay].chatLog.ToString());
            string nextBlock = (conversations[ServiceLocator._messageTiming.currentDay].mood.ToString() + conversations[ServiceLocator._messageTiming.currentDay].chatLog.ToString());
            ServiceLocator._flowchart.ExecuteBlock(nextBlock);
        }
        else
        {
            //change game state to where January isn't present on the page'
        }
    }

    public void EndConversation() //call this at the end of a conversation to perform setup for the next conversation
    {
        //testing if you run QueueMessage() it should take you to a new conversation 
        ServiceLocator._messageTiming.SetGoalTime();
  
    }

    public void SaveConversation()
    {
       // ES3.Save<SaveData>("conversations",conversations);
        Debug.Log(conversations.Count);
        Debug.Log("your current conversation has been saved, hopefully");
    }
    
    
}
