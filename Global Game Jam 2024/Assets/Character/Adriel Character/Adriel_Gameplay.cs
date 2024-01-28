using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
///     Passive
/// </summary>
public class AdrielPassive : Passive {
    public Character Adriel;
    public Character other;
    
    private void Awake() {
        Adriel = GetComponent<Character_Adriel>();
        if (Adriel == null) {
            Debug.LogError("no adriel ref in adriel gameplay");
        }
    }
   
    
    public override void ActivatePassive() {
        if (!other.isSad) {
            Adriel.PlaySound("it is what it is!");
            other.currentDefense = 0;
        }
        else if (other.isSad && !other.isDepressed) {
            other.currentDefense= -1;
        }
        else {
            Debug.Log("Already depressed: " + other.name);
        }
    }
}


/// <summary>
///     Skill Ability
/// </summary>
public class AdrielSkill : Skill {
    public Character_Adriel Adriel;

    private void Awake() {
        Adriel = GetComponent<Character_Adriel>();
        if (Adriel == null) {
            Debug.LogError("no adriel ref in adriel gameplay");
        }
    }

    void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                Adriel.PlaySound("it is what it is...");
                break;
            case 2:
                Adriel.PlaySound("it is what it is.");
                break;
        }
    }
    
    public override void ActivateSkill()
    {
        if (!Adriel.isTaunting) {
            useVoiceline();
            Adriel.isTaunting = true;
            Adriel.currentDefense = Adriel.defenseOnTaunt;
        }
    }
}


/// <summary>
///     Ultimate Ability
/// </summary>
public class AdrielUltimate : Ultimate {
    public Character_Adriel Adriel;
    public Character other;

    private void Awake() {
        Adriel = GetComponent<Character_Adriel>();
        if (Adriel == null) {
            Debug.LogError("no adriel ref in adriel gameplay");
        }
    }
    
    void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                Adriel.PlaySound("it is what it is...");
                break;
            case 2:
                Adriel.PlaySound("it is what it is.");
                break;
        }
    }
    public override void UseUltimate() {
        useVoiceline();
        other.isDepressed = true;
    }
}

