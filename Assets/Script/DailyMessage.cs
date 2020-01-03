using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DailyMessage : MonoBehaviour
{
    public bool timeset;
   // public Block nextConversation;
    protected List<DialogManager.Dialog> conversations;
    public Block startingConversation;


    // Start is called before the first frame update
    void Start()
    {
        timeset = true;
        //setFirstConversation();
        ServiceLocator._messageTiming.SetGoalTime();
        QueueMessage();
    }
    
    public void setFirstConversation() //sets the first conversation of the game manually if don't want it to be random'
    {
        startingConversation = ServiceLocator._flowchart.FindBlock("HappyMessage1");
        ServiceLocator._flowchart.ExecuteBlock(startingConversation);
    }

    public void QueueMessage() // queue everything for the set amount of days to play (5 for starting) 
    {
        if (conversations == null) //if conversations doesn't exist we create a list of the messages with how many days the player can play '
        { 
            conversations = new List<DialogManager.Dialog>();
           // currentDay = 0; 
            for (int i = 0; i < ServiceLocator._messageTiming.lengthOfGame; i++)
            {
                conversations.Add(ServiceLocator._dialogManager.LoadMessage());
            }
        }
        //conversations[0].mood
        Debug.Log(conversations[0].mood.ToString()); 
        Debug.Log(conversations[0].chatLog.ToString());
        Debug.Log(conversations[0].mood.ToString()+conversations[0].chatLog.ToString());
       // string nextBlock = (conversations[currentDay].mood.ToString() + conversations[currentDay].chatLog.ToString());
        Debug.Log("how many conversationgs loaded "+conversations.Count);
       // ServiceLocator._flowchart.ExecuteBlock(nextBlock);
        if (ServiceLocator._messageTiming.CheckTimeMet()) // make this prettier create a toString function in the DialogManager that does this for me? 
        {
            
           

        }
        else
        {
            //change game state to where January isn't present on the page'
        }
    }
    
    
}
