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
        
        // queue each notification
        pushNotifications.Enqueue("you received a new message");
        pushNotifications.Enqueue("January wants to chat");
        pushNotifications.Enqueue("are you there? ");
        

        Debug.Log(pushNotifications.Dequeue().ToString());
        
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(15, 3,0),
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
