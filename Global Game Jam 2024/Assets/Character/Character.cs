using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //public for now (maybe change later?)
    public float health= 100.0f;
    public float defense= 20.0f;
    public float attackDMG= 15.0f;
    //array for debuffs
    bool isSad, isDepressed, isTaunting, isTaunted, isDoubting;
    //passive, attack, ultimate

    //actions: attack, heal, 
    abstract public void StartTurn();
    void Update()
    {
        
    }
}
