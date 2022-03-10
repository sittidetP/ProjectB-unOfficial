using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertTextManager : MonoBehaviour
{
    [SerializeField] TMP_Text alertText;
    
    

    public void SetTextPosition(Transform transform){
        alertText.gameObject.transform.position = transform.position;
    }
}
