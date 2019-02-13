using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR    
using UnityEditor;
#endif

namespace AdamGu { }

public class CreateAIBehaviorFolder : MonoBehaviour {

#if UNITY_EDITOR
    [MenuItem("AITool/CreateFolder")]
    public static void Create()
    {
        CreateFolders();
    }
    private static void CreateFolders()
    {
        string m_dataPath = Application.dataPath;
        if (m_dataPath.StartsWith(Application.dataPath))
        {
            m_dataPath = m_dataPath.Substring(Application.dataPath.Length - "Assets".Length);
        }

        //Debug.Log(m_dataPath);
        //Create a base folder to contain ai setting data
        string baseFolder="A_Data";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder))
        {
            Debug.Log("Success Create " + baseFolder + " Folder");
            AssetDatabase.CreateFolder(m_dataPath, baseFolder);
        }
        else
            Debug.Log(baseFolder + " Folder Already Exists");
        //folders in A_Data
        string folderName;
        folderName = "LearnedBehavior";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder+"/"+ folderName))
        {
            Debug.Log("Success Create " + folderName + " Folder");
            AssetDatabase.CreateFolder(m_dataPath+"/"+baseFolder, folderName);
        }
        else
            Debug.Log(folderName + " Folder Already Exists");

        folderName = "DecideEvent";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder + "/" + folderName))
        {
            Debug.Log("Success Create " + folderName + " Folder");
            AssetDatabase.CreateFolder(m_dataPath + "/" + baseFolder, folderName);
        }
        else
            Debug.Log(folderName + " Folder Already Exists");

        folderName = "Decisions";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder + "/" + folderName))
        {
            Debug.Log("Success Create " + folderName + " Folder");
            AssetDatabase.CreateFolder(m_dataPath + "/" + baseFolder, folderName);
        }
        else
            Debug.Log(folderName + " Folder Already Exists");

        folderName = "Sensors";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder + "/" + folderName))
        {
            Debug.Log("Success Create " + folderName + " Folder");
            AssetDatabase.CreateFolder(m_dataPath + "/" + baseFolder, folderName);
        }
        else
            Debug.Log(folderName + " Folder Already Exists");

        folderName = "ExtraScripts";
        if (!Directory.Exists(m_dataPath + "/" + baseFolder + "/" + folderName))
        {
            Debug.Log("Success Create " + folderName + " Folder");
            AssetDatabase.CreateFolder(m_dataPath + "/" + baseFolder, folderName);
        }
        else
            Debug.Log(folderName + " Folder Already Exists");
        AssetDatabase.Refresh();
    }
#endif
}
