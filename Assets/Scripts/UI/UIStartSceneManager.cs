using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartSceneManager : MonoBehaviour
{
    [SerializeField] string startScene;

    public void StartButton(){
        SceneManager.LoadScene(startScene);
    }
    public void ExitButton(){
        Application.Quit();
    }
}
