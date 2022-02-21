using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartSceneManager : UISceneChanger
{
    [SerializeField] string gameplayScene;

    public void ToGameplayScene(){
        SceneManager.LoadScene(gameplayScene);
    }
}
