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
    abstract public void TakeDamage();
    abstract public void DealDamage();
    abstract public void Update();


    //  returns the character chosen/acted upon. 
    //  method takes the character's method to use (returns a bool), and a list of characters to use it on (can be 1, or many)
    Character ChooseTarget(Func<Character, bool> characterMethod, List<Character> characters) {
        //  for all Characters inside the array...
        foreach (Character character in characters) {
            //  if the character method can be called on that character...
            if (characterMethod(character)) {
                //  return that character (might leave if void)
                return character;
            }
        }
        
        //  if nothing targettable, return void.
        return null;
        
        
    }
}
