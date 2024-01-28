using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Diana : Character {
    bool endTurn = false;


    public override bool StartTurn(int currentSkillPointCount) {
        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("Diana's Turn Has Ended");
            return false;
        }

        return true;
    }
    

    protected override void InitiateSoundEffects()
    {
        characterSoundEffects.Add("Talent", Resources.Load<AudioClip>("Sounds/talentSoundDiana.ogg"));
        characterSoundEffects.Add("Skill", Resources.Load<AudioClip>("Sounds/skillSoundDiana.ogg"));
        characterSoundEffects.Add("Ultimate", Resources.Load<AudioClip>("Sounds/talentSoundDiana.ogg"));
    }

    private void Awake()
    {
        name = "Diana";
        baseHealth = 125.0f;
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        currentAttack = baseAttack;
    }
}