﻿using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;


public class ServiceLocator 
{
   //reference for all game managers this is created in the Game.cs
   
   public static Game _game;
   public static DialogManager _dialogManager;
   public static DailyMessage _dailyMessage;
   public static MessageTiming _messageTiming;
   public static AudioManager _audioManager;
   public static Flowchart _flowchart;

   public static CanvasScaler _messagerCanvas; 
   public static SaveLoad _saveLoad;
   public static QueueSample _queueSample; //this is the simple pushnotification script


}
