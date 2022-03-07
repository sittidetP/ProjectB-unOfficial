using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected ItemDroper itemDroper;

    public AudioSource AudioSource {get; private set;}

    public override void Awake()
    {
        base.Awake();

        AudioSource = GetComponent<AudioSource>();
    }
}
