using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseImage : MonoBehaviour
{
    public void ResumeButton()
    {
        if (PauseManager.isPause)
        {
            PauseManager.resume();
        }
    }
}
