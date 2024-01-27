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
    abstract public int StartTurn(int currentSkillPointCount);
    public void TakeDamage(float recievedDamage) {
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (defense / 100.0f));
        health -= damageTaken;
    }
    abstract public void Update();

}

public class CharacterAdriel : Character {
    public override int StartTurn(int currentSkillPointCount) {
        if (currentSkillPointCount == 0) {
            Debug.Log("NO SKILLPOINTS! you whore.");
            return currentSkillPointCount;
        }
        
        return currentSkillPointCount;
    }
    public override void Update()
    {


    }
}