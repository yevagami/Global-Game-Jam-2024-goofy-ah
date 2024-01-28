using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Adriel : Character
{
    bool endTurn = false;
    public float defenseOnTaunt = 30.0f;
    
    public override bool StartTurn(int currentSkillPointCount) {
        if (Input.GetKeyUp(KeyCode.B)) { 
        
            Debug.Log("Adriel's Turn Has Ended");
            return false;
        }

        return true;
    }
    
    void useOuchieVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                PlaySound("double giggle");
                break;
            case 2:
                PlaySound("long giggle");
                break;
        }
    }

    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("it is what it is...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 1"));   
        characterSoundEffects.Add("it is what it is!", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 2"));   
        characterSoundEffects.Add("it is what it is.", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 3"));   
        characterSoundEffects.Add("shut up.", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 4"));   
        characterSoundEffects.Add("the mask...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel Skill1"));   
        characterSoundEffects.Add("the mask!", Resources.Load<AudioClip>("Sounds/Adriel/Adriel Skill2"));   
        characterSoundEffects.Add("respectfully...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 5"));   
        characterSoundEffects.Add("double giggle", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 6"));   
        characterSoundEffects.Add("long giggle", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 7"));   
        
        Debug.Log("Adriel has a voice! we're so happy");
    }

    public override void TakeDamage(float recievedDamage) {
        useOuchieVoiceline();
        base.TakeDamage(recievedDamage);
    }


    private void Awake()
    {
        name = "Adriel";
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        currentAttack = baseAttack;
    }
}
