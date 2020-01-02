using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTiming : MonoBehaviour
{
    public Time timeStampLastMessage, timeStampNextMessage; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGoalTime()
    {
        timeStampLastMessage = new Time();   
    }
}
