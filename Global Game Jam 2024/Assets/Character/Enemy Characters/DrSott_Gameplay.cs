using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
///     PASSIVE ABILITY
/// </summary>
public class SottPassive : Passive {
    public Character_DrSottLeaver DrSottLeaver;

    private void Awake()
    {
        DrSottLeaver = GetComponent<Character_DrSottLeaver>();
        if (DrSottLeaver == null)
        {
            Debug.LogError("No Sott in DrScott Gameplay");
        }
    }

    private void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("picking up fish");
                break;
            case 2:
                DrSottLeaver.PlaySound("butcher shop");
                break;
        }
    }
    
    public override void ActivatePassive() {
        useVoiceline();
        
        if (DrSottLeaver.currentLeaveChance < 80.0f) DrSottLeaver.currentLeaveChance += DrSottLeaver.currentLeaveIncrementPerTurn;
        if (!(Random.Range(0.0f, 100.0f) < DrSottLeaver.currentLeaveChance)) return;
        
        DrSottLeaver.hasLeft = true;
        Debug.Log("Sott has left.");
    }
}

/// <summary>
///     ACTIVE SKILL
/// </summary>
public class DrSottLeaverAttack : Skill {
    public Character_DrSottLeaver DrSottLeaver;
    public Character_Adriel adriel;
    public Character_Diana diana;
    public Character_Michael michael;

    private void Awake()
    {
        DrSottLeaver = GetComponent<Character_DrSottLeaver>();
        if (DrSottLeaver == null)
        {
            Debug.LogError("No Sott in DrScott Gameplay");
        }
    }
    
    private void useVoiceline() {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("dont piss me off");
                break;
            case 2:
                DrSottLeaver.PlaySound("get this done");
                break;
            case 3:
                DrSottLeaver.PlaySound("back to work");
                break; 
        }
    }

    public override void ActivateSkill() {
        useVoiceline();

        adriel.TakeDamage(DrSottLeaver.currentAttack);
        diana.TakeDamage(DrSottLeaver.currentAttack);
        michael.TakeDamage(DrSottLeaver.currentAttack);
    }
}


/// <summary>
///     Ultimate Ability
/// </summary>
public class DrSottLeaverUltimate : Ultimate {
    public Character_DrSottLeaver DrSottLeaver;

    private void Awake()
    {
        DrSottLeaver = GetComponent<Character_DrSottLeaver>();
        if (DrSottLeaver == null)
        {
            Debug.LogError("No Sott in DrScott Gameplay");
        }
    }
    
    private void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("public variables...");
                break;
            case 2:
                DrSottLeaver.PlaySound("public variables extended");
                break;
        }
    }

    //  "Sets to Public"
    public override void UseUltimate() {
        useVoiceline();


        
        //  LOGIC HERE
    }
}