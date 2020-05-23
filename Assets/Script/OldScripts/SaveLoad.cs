using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Boo.Lang.Environments;
using Fungus;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static List<DialogManager.Dialog> myData;
    public static DateTime myDataTime; 
   
    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/SaveData.es3"))
        {
            myData = ES3.Load<List<DialogManager.Dialog>>("conversations");
            myDataTime = ES3.Load<DateTime>("nextMessage");
        }
    }

    private void OnApplicationQuit()
    {
        //throw new NotImplementedException();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
       
    }

   
}
