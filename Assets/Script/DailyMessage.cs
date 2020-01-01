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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFirstConversation() //sets the first conversation of the game manually if don't want it to be random'
    {
        startingConversation = ServiceLocator._flowchart.FindBlock("Happy-0");
        ServiceLocator._flowchart.ExecuteBlock(startingConversation);
    }

    public void QueueMessage()
    {
        if (timeset)
        {
            conversations = new List<DialogManager.Dialog>();
            conversations.Add(ServiceLocator._dialogManager.LoadMessage());
            //conversations[0].mood
            Debug.Log(conversations[0].mood.ToString()); 
            Debug.Log(conversations[0].chatLog.ToString());

        }
        else
        {
            //change game state to where January isn't present on the page'
        }
    }
}
