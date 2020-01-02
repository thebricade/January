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
        QueueMessage();
    }
    
    public void setFirstConversation() //sets the first conversation of the game manually if don't want it to be random'
    {
        startingConversation = ServiceLocator._flowchart.FindBlock("HappyMessage1");
        ServiceLocator._flowchart.ExecuteBlock(startingConversation);
    }

    public void QueueMessage() // queue everything for the set amount of days to play (5 for starting) 
    {
        if (timeset) // make this prettier create a toString function in the DialogManager that does this for me? 
        {
            conversations = new List<DialogManager.Dialog>();
            conversations.Add(ServiceLocator._dialogManager.LoadMessage());
            //conversations[0].mood
            Debug.Log(conversations[0].mood.ToString()); 
            Debug.Log(conversations[0].chatLog.ToString());
            Debug.Log(conversations[0].mood.ToString()+conversations[0].chatLog.ToString());
            string nextBlock = (conversations[0].mood.ToString() + conversations[0].chatLog.ToString());
           ServiceLocator._flowchart.ExecuteBlock(nextBlock);

        }
        else
        {
            //change game state to where January isn't present on the page'
        }
    }
    
    
}
