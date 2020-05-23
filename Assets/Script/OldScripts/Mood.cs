using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


//try this with enum if you forget how to do it see Danny! 



public class Mood : MonoBehaviour {
	

	
	//set an array of moods
	public List<string> moodList= new List<string>{"Anxious","Panic", "Happy", "Angry", "Sad", "Mono", "Hyper"};
	//public string[] moodList = {"Anxious", "Panic", "Happy", "Angry", "Sad", "Mono", "Hyper"};
	public Text playerMood;
	public string displayedMood;
	
	//variable for each mood pick
	[HideInInspector] public int moodPick;
	public int anxiousPick;
	public int panicPick;
	public int happyPick;
	public int angryPick;
	public int sadPick;
	public int monoPick;
	public int HyperPick;
	public string destroyMoment;
	
	
	//set arrays for each mood to store the day dialog 
	public List<int> anxiousMoments = new List<int> {0, 1, 2, 3, 4};
	public List<int> panicMoments = new List<int> {0, 1, 2, 3, 4};
	public List<int> happyMoments = new List<int> {0, 1, 2, 3, 4};
	public List<int> angryMoments = new List<int> {0, 1, 2, 3, 4};
	public List<string> sadMoments = new List<string> {"0", "1","2","3","4"};
	public List<int> monoMoments = new List<int> {0, 1, 2, 3, 4};
	public List<int> hyperMoments = new List<int> {0, 1, 2, 3, 4};
	
	//public int[] anxiousMoments = {0, 1, 2, 3, 4};
	//public int[] panicMoments = {0, 1, 2, 3, 4};
	//public int[] happyMoments = {0, 1, 2, 3, 4};
	//public int[] angryMoments = {0, 1, 2, 3, 4};
	//public int[] sadMoments = {0, 1, 2, 3, 4};
	//public int[] monoMoments = {0, 1, 2, 3, 4};
	//public int[] hyperMoments = {0, 1, 2, 3, 4};
	
	//Variables to make players wait a day between conversations
	public DateTime timeNow;
	public DateTime timeGoal;
	public bool timeFinished;
	public DateTime debugAddTime;


	// Use this for initialization
	
	void Start () {
		
		//declare each of the moods in the list
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space"))
		{
			timeNow = timeNow.AddDays(1);
			Debug.Log(timeNow);
			checkTime();
			checkMood();
		}
		
	
		
	}

	public void checkMood()
	{
		//Set the current time and set the goal for one day later
		if (timeFinished == false)
		{
			timeNow = DateTime.Now;
			timeGoal = timeNow.AddDays(1);
			Debug.Log(timeNow);
			Debug.Log(timeGoal);
		}

		//if the time goal has been finished then they can get a new dialog for the day
		if (timeFinished == true)
		{
			//Enum.GetValues(typeof(MoodList));
			
			moodPick = Random.Range(0, moodList.Count);
			displayedMood = moodList[4];
			//displayedMood = moodList[moodPick];
			playerMood.text = "Mood: " + displayedMood;
			
			
			if (displayedMood == "Anxious")
			{
				isAnxious();
			}
			else if (displayedMood == "Panic")
			{
				isPanic();
			}
			else if (displayedMood == "Happy")
			{
				isHappy();
			}
			else if (displayedMood == "Angry")
			{
				isAngry();
			}
			else if (displayedMood == "Sad")
			{
				isSad();
			}
			else if (displayedMood == "Mono")
			{
				isMono();
			}
			else if (displayedMood == "Hyper")
			{
				isHyper();
			}
		}
	}

	public void checkTime()
	{
		if (timeNow >= timeGoal)
		{
			timeFinished = true;
			
		}
	}

	public void isAnxious()
	{
		var anxiousPickIndex = Random.Range(0, anxiousMoments.Count);
		anxiousPick = anxiousMoments[anxiousPickIndex];
		anxiousMoments.RemoveAt(anxiousPickIndex);
		

		destroyMoment = "anxious";
		Fungus.Flowchart.BroadcastFungusMessage("Anxious"+anxiousPick);
	}
	
	public void isPanic()
	{
		panicPick = Random.Range(0, panicMoments.Count);
		destroyMoment = "panic";
		Fungus.Flowchart.BroadcastFungusMessage("Panic"+panicPick);
	}
	
	public void isHappy()
	{
		happyPick = Random.Range(0, happyMoments.Count);
		destroyMoment = "happy";
		Fungus.Flowchart.BroadcastFungusMessage("Happy"+happyPick);
	}
	
	public void isAngry()
	{
		angryPick = Random.Range(0, angryMoments.Count);
		destroyMoment = "angry";
		Fungus.Flowchart.BroadcastFungusMessage("Angry"+angryPick);
	}
	
	public void isSad()
	{
		sadPick = Random.Range(0, sadMoments.Count);
		print("sadPick: " + sadPick);
		destroyMoment = "sad";
		Fungus.Flowchart.BroadcastFungusMessage("Sad"+sadPick);
	}
	
	public void isMono()
	{
		monoPick = Random.Range(0, monoMoments.Count);
		destroyMoment = "mono";
		Fungus.Flowchart.BroadcastFungusMessage("Mono"+monoPick);
	}
	
	public void isHyper()
	{
		HyperPick = Random.Range(0, hyperMoments.Count);
		destroyMoment = "hyper";
		Fungus.Flowchart.BroadcastFungusMessage("Hyper"+HyperPick);
	}

	public void deleteMoment()
	{
		if (destroyMoment == "anxious")
		{
			anxiousMoments.RemoveAt(anxiousPick);
		}else if (destroyMoment == "panic")
		{
			panicMoments.RemoveAt(panicPick);
		}else if (destroyMoment == "happy")
		{
			happyMoments.RemoveAt(happyPick);
		}else if (destroyMoment == "angry")
		{
			angryMoments.RemoveAt(angryPick);
		}else if (destroyMoment == "sad")
		{
			print("deleting " + sadPick);
			sadMoments.Remove(sadPick.ToString());
			//Debug.Log(sadMoments);
			
		}else if (destroyMoment == "mono")
		{
			monoMoments.RemoveAt(monoPick);
		}else if (destroyMoment == "hyper")
		{
			hyperMoments.RemoveAt(HyperPick);
		}
		
	}
}


