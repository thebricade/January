using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_IOS
    using NotificationServices = UnityEngine.iOS.NotificationServices;
    using NotificationType = UnityEngine.iOS.NotificationType;
    using UnityEngine.iOS;
#elif UNITY_ANDROID
    
#endif



public class Game : MonoBehaviour
{
    public static Game current;
    public static int lengthOfGame;
    private static DeviceGeneration generation;
    private static string deviceModel; 
    
    // Start is called before the first frame update
    void Awake()
    {
        _InitializeServices();
        SetUpGame();
    }

    public void _InitializeServices()
    {
        ServiceLocator._game = this;
        ServiceLocator._saveLoad = gameObject.AddComponent<SaveLoad>();
        ServiceLocator._queueSample = gameObject.AddComponent<QueueSample>();
        ServiceLocator._messagerCanvas = GameObject.Find("MessengerCanvas").GetComponent<CanvasScaler>(); 
        ServiceLocator._flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        ServiceLocator._dialogManager = gameObject.AddComponent<DialogManager>();
        ServiceLocator._audioManager = gameObject.AddComponent<AudioManager>();
        ServiceLocator._dailyMessage = gameObject.GetComponent<DailyMessage>();
        ServiceLocator._messageTiming = gameObject.AddComponent<MessageTiming>();
        
        
        
    }

    private void SetUpGame()
    {
        #if UNITY_IOS
            // iOS stuff 
            
            NotificationServices.RegisterForNotifications(
                NotificationType.Alert |
                NotificationType.Badge|
                NotificationType.Sound);
            
           
            if (generation == DeviceGeneration.iPhone6 || generation == DeviceGeneration.iPhone6S)
            {
                //any set code for here
            }

            if (generation == DeviceGeneration.iPhoneX)
            {
                //lalalala
            }
            
           
            //ServiceLocator._messagerCanvas.matchWidthOrHeight = 1f; 
#elif UNITY_ANDROID
            //android stuff
#elif UNITY_STANDALONE_WIN
            //WINDOWS BUILD
#endif

    }


}
