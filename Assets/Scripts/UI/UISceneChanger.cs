using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISceneChanger : MonoBehaviour
{
    [SerializeField] protected string startScene = "StartScene";
    

    public virtual void ToStartScene(){
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame(){
        Application.Quit();
    }

}
