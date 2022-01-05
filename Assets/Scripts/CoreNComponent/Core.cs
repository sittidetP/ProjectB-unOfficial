using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement 
    {
        get => GenericsNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value; 
    }
    public CollisionSenses CollisionSenses 
    {
        get => GenericsNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }

    public Combat Combat
    {
        get => GenericsNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    public Stats Stats
    {
        get => GenericsNotImplementedError<Stats>.TryGet(stats, transform.parent.name);
        private set => stats = value;
    }

    private Movement movement;

    private CollisionSenses collisionSenses;

    private Combat combat;

    private Stats stats;
    private List<ILogicUpdate> components = new List<ILogicUpdate>();

    void Awake()
    {
        movement = GetComponentInChildren<Movement>();
        collisionSenses = GetComponentInChildren<CollisionSenses>();
        combat = GetComponentInChildren<Combat>();
        stats = GetComponentInChildren<Stats>();
    }

    public void LogicUpdate()
    {
        foreach (ILogicUpdate component in components)
        {
            component.LogicUpdate();
        }
    }

    public void AddComponent(ILogicUpdate component)
    {
        //Check to make sure components is not already part of the list - .Contains() comes from the Linq library we added.
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }
}
