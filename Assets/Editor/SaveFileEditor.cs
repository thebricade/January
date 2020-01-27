using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Game))]
public class SaveFileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Delete Save File"))
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.es3"))
            {
                File.Delete(Application.persistentDataPath +"/SaveData.es3");
            }
           
        }
    }
}
