using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Character : MonoBehaviour
{
    //public for now (maybe change later?)
    public float health = 100.0f;
    public float defense= 20.0f;
    public float attackDMG= 15.0f;
    //array for debuffs
    public bool isSad, isDepressed, isTaunting, isTaunted, isDoubting;
    public bool canFollowUp;
    public bool isBuffed, isAltered;
    //passive, attack, ultimate
    
    
    //actions: attack, heal, 
    abstract public void StartTurn();
    public void TakeDamage(float recievedDamage) {
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (defense / 100.0f));
        health -= damageTaken;
    }
    abstract public void DealDamage();
    abstract public void Update();

}

public class CharacterAdriel : Character {
    public override void StartTurn()
    {
        throw new NotImplementedException();
    }
    public override void DealDamage()
    {
        throw new NotImplementedException();
    }
    public override void Update()
    {


    }
}