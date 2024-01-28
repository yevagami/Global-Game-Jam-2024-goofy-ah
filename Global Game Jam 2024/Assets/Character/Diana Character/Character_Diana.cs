using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Diana : Character {
    bool endTurn = false;


    public override bool StartTurn(int currentSkillPointCount) {
        if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("Diana's Turn Has Ended");
            return false;
        }

        return true;
    }

    void useOuchieVoiceline() {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                PlaySound("son of a birch");
                break;
            case 2:
                PlaySound("i dont like that...");
                break;
            case 3:
                PlaySound("heyy");
                break;
        }
    }
    public override void TakeDamage(float recievedDamage) {
        useOuchieVoiceline();

       base.TakeDamage(recievedDamage);
    }

    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("a little bit for you!", Resources.Load<AudioClip>("Sounds/Diana/Diana 1"));
        characterSoundEffects.Add("a little bit for you~", Resources.Load<AudioClip>("Sounds/Diana/Diana 2"));
        characterSoundEffects.Add("a little bit for you!~", Resources.Load<AudioClip>("Sounds/Diana/Diana 3"));
        characterSoundEffects.Add("it IS about me", Resources.Load<AudioClip>("Sounds/Diana/Diana 4"));
        characterSoundEffects.Add("it IS about ME", Resources.Load<AudioClip>("Sounds/Diana/Diana 5"));
        characterSoundEffects.Add("come on guys", Resources.Load<AudioClip>("Sounds/Diana/Diana 6"));
        characterSoundEffects.Add("come on guys!~", Resources.Load<AudioClip>("Sounds/Diana/Diana 7"));
        characterSoundEffects.Add("son of a birch", Resources.Load<AudioClip>("Sounds/Diana/Diana 8"));
        characterSoundEffects.Add("i dont like that...", Resources.Load<AudioClip>("Sounds/Diana/Diana 9"));
        characterSoundEffects.Add("heyy", Resources.Load<AudioClip>("Sounds/Diana/Diana 12"));
        
        Debug.Log("Diana unfortunately can use her voice in game :(");
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