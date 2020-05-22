using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class MessageTiming : MonoBehaviour
{
    public DateTime timeStampLastMessage, timeStampNextMessage;
    private bool goalTime; 
    
    //quick debug amount of Days for messages
    public int lengthOfGame = 2;
    public int currentDay =0; 
    
    public void SetGoalTime()
    {
        goalTime = false; 
        Debug.Log("ran set goal time");
        timeStampLastMessage = DateTime.Now;
        Debug.Log("current time " +timeStampLastMessage);
        timeStampNextMessage = timeStampLastMessage.AddMinutes(3);
        Debug.Log(("next message will appear at " + timeStampNextMessage));
        //ServiceLocator._game.RunSave();
    }

    public bool CheckTimeMet()
    {
        if (timeStampNextMessage >= timeStampLastMessage)
        {
            goalTime = true;
        }
        else
        {
            goalTime = false;
        }

        return goalTime; 
    }

    public int ReturnCurrentDay()
    {
        Debug.Log("current day is "+ currentDay );
        return currentDay; 
    }

    public int AddDay()
    {
        currentDay++;
        return currentDay;
    }
}
