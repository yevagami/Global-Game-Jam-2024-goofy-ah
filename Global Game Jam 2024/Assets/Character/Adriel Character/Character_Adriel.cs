using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Adriel : Character
{
    bool endTurn = false;
    public float defenseOnTaunt = 30.0f;
    
    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("Adriel's Turn Has Ended");
            return false;
        }

        return true;
    }

    protected override void InitiateSoundEffects()
    {
        
    }

    private void Awake()
    {
        name = "Adriel";
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        currentAttack = baseAttack;
    }
}
