using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneChanger : MonoBehaviour
{
    [SerializeField] protected string startScene = "StartScene";

    public void ToStartScene(){
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
