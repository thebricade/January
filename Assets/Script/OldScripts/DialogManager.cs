using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private Dictionary<GameMood, List<int>> possibleScenes = new Dictionary<GameMood, List<int>>();
    
    public class Dialog // I need this section to be walked through so I understand what I did
    {
        public enum GameMood
        {
            //Anxious, 
            //Panic, 
            //Happy, 
            //Angry,
            Sad, 
            //Mono, 
            //Hyper
        }

        public enum MessageNumber
        {
            Message1,
            Message2,
            Message3,
            Message4,
            Message5
        }

        public GameMood mood;
        public MessageNumber chatLog;

        //public List<int> chatLog;
        
        public Dialog(GameMood mood, MessageNumber chatLog)
        {
            this.mood = mood;
            this.chatLog = chatLog; 
        }

        public Dialog()
        {
            this.mood = GameMood.Sad;
            this.chatLog = MessageNumber.Message1;
        }
        
    }

    public static ShuffleBag<Dialog> messages;

    private void Awake()
    {
        //check if the messages have been set up
        if (!isVaildMessages())
        {
            messages = new ShuffleBag<Dialog>();
            Debug.Log("creating a new queue of dialogs");
            AddDialogToMessages();
        }
    }

    protected virtual bool isVaildMessages()
    {
        return messages != null; 
    }

    protected virtual void AddDialogToMessages()
    {
        foreach (Dialog.GameMood mood in Dialog.GameMood.GetValues(typeof(Dialog.GameMood)))
        {
            foreach (Dialog.MessageNumber chatLog in Dialog.MessageNumber.GetValues(typeof(Dialog.MessageNumber)))
            {
                Debug.Log("adding all moods and messages options into the game");
                messages.Add(new Dialog(mood, chatLog));
            }
        }

        //LoadMessage();
        // messages.Add(new Dialog(Dialog.GameMood.Anxious));
    }

    public virtual Dialog LoadMessage()
    {
        Dialog nextMessage = messages.Next();
        Debug.Log("added "+nextMessage.mood.ToString()+nextMessage.chatLog.ToString() + " to conversation queue");
        return nextMessage; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void PickDialog()
    {
       
    }
}




        
