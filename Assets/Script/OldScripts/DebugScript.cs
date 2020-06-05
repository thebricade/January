using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DebugScript : MonoBehaviour
{
    public TMP_Text  nextMessageTime;
    public TMP_Text nextMessageName; 
     
    // Start is called before the first frame update
    void Start()
    {
        nextMessageTime.text = "Next Message at "+  ServiceLocator._messageTiming.timeStampNextMessage.ToString();
        nextMessageName.text = ServiceLocator._dailyMessage.nextConversationDebug; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateDebug()
    {
        nextMessageTime.text = "Next Message at "+ ServiceLocator._messageTiming.timeStampNextMessage.ToString();
        nextMessageName.text = ServiceLocator._dailyMessage.nextConversationDebug;
    }
}
