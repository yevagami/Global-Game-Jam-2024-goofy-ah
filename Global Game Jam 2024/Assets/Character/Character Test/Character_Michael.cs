using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Michael : Character
{

    bool endTurn = false;

    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("Michael's Turn Has Ended");
            return false;
        }

        return true;
    }

    private void Awake() {
        name = "Michael";
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        baseAttack = 25.0f; currentAttack = baseAttack;
    }

    public override void Update()
    {
        return;
    }

    protected override void InitiateSoundEffects()
    {
        return;
    }

    
}
