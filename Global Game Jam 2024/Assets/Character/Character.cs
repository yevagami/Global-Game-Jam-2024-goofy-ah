using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //public for now (maybe change later?)
    public float health = 100.0f;
    public float defense= 20.0f;
    public float attackDMG= 15.0f;
    //array for debuffs
    public bool isSad, isDepressed, isTaunting, isTaunted, isDoubting;
    public bool followupChance;
    public bool isBuffed, isAltered;
    //passive, attack, ultimate

    //actions: attack, heal, 
    abstract public void StartTurn();
    abstract public void TakeDamage();
    abstract public void DealDamage();
    abstract public void Update();
}
