using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newWrapStateData", menuName = "Data/Enemy Data/WrapStateData")]
public class BaseWrapStateData : ScriptableObject
{
    [SerializeField] float countdownTime = 2f;
    public float CountdownTime => countdownTime;
    [SerializeField] float cooldownTime = 2f;
    public float CooldownTime => cooldownTime;
}
