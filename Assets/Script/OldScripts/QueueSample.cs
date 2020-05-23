using System;
using System.Collections;
using System.Collections.Generic;
using LocalNotification = UnityEngine.iOS.LocalNotification;
using Unity.Notifications.iOS; 
using UnityEngine;

public class QueueSample : MonoBehaviour
{
    Queue pushNotifications = new Queue();
    // Start is called before the first frame update
    void Start()
    {
        //pushNotifications = SaveLoad.myDataPushNotification;
        pushNotifications = ES3.Load("pushNotifications", pushNotifications); 
        // queue each notification
        if (pushNotifications.Count == 0)
        {
            pushNotifications.Enqueue("you received a new message");
            pushNotifications.Enqueue("January wants to chat");
            pushNotifications.Enqueue("are you there? ");
            
            //save our push notifications
            ES3.Save<Queue>("pushNotifications",pushNotifications);
        }


        Debug.Log(pushNotifications.Dequeue().ToString());
        
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(0, 3,0),
            Repeats = false
        };
        
        var notification = new iOSNotification()
        {
            Identifier = "_notification_01",
            Title = "January",
            Body = pushNotifications.Dequeue().ToString(),
            Subtitle = "",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };
    }
    
    public void AddPush(string pushText)
    {
        pushNotifications.Enqueue(pushText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
