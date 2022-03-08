using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private static readonly string SAVE_OPTION_FOLDER = Application.dataPath + "/Saves/";
    
    private const string SAVE_EXTENSION = "txt";

    public static void Init() {
        // Test if Save Folder exists
        if (!Directory.Exists(SAVE_FOLDER)) {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString){
        File.WriteAllText(SAVE_FOLDER + "save" + "." + SAVE_EXTENSION, saveString);
    }

    public static string Load(){
        if(File.Exists(SAVE_FOLDER + "save" + "." + SAVE_EXTENSION)){
            string saveString = File.ReadAllText(SAVE_FOLDER + "save" + "." + SAVE_EXTENSION);
            return saveString;
        }
        return null;
    }

    public static bool HasSave(){
        if(File.Exists(SAVE_FOLDER + "save" + "." + SAVE_EXTENSION)){
            return true;
        }
        return false;
    }

}
