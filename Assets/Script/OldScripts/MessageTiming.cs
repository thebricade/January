using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class MessageTiming : MonoBehaviour
{
    public DateTime timeStampLastMessage, timeStampNextMessage;
    private bool goalTime; 
    
    //quick debug amount of Days for messages
    public int lengthOfGame = 3;
    public int currentDay =0; 
    
    public void SetGoalTime()
    {
        timeStampNextMessage = SaveLoad.myDataTime;
        goalTime = false; 
        Debug.Log("ran set goal time");
        timeStampLastMessage = DateTime.Now;
        Debug.Log("current time " +timeStampLastMessage);
        timeStampNextMessage = timeStampLastMessage.AddMinutes(3);
        Debug.Log(("next message will appear at " + timeStampNextMessage));
        
        //saving the Time for next message
        ES3.Save<DateTime>("nextMessage", timeStampNextMessage);

        //ES3.Save("myDataTime",timeStampNextMessage);
        //ServiceLocator._game.RunSave();
    }

    public bool CheckTimeMet()
    {
        timeStampNextMessage = ES3.Load("nextMessage", timeStampNextMessage);
        Debug.Log(timeStampLastMessage.ToString());
        Debug.Log(timeStampNextMessage.ToString());
        if (DateTime.Now > timeStampNextMessage)
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
