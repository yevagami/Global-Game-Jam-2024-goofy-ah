using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_DrSottLeaver : Character {
    public bool hasLeft = false;
    public float currentLeaveChance;
    public float currentLeaveIncrementPerTurn = 5.0f;
    
    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("dont piss me off", Resources.Load<AudioClip>("Sounds/Dr Sott/dont piss me off"));
        characterSoundEffects.Add("back to work", Resources.Load<AudioClip>("Sounds/Dr Sott/get back to work"));
        characterSoundEffects.Add("picking up fish", Resources.Load<AudioClip>("Sounds/Dr Sott/i need to go to pick up some fish"));
        characterSoundEffects.Add("tangents", Resources.Load<AudioClip>("Sounds/Dr Sott/if i had a normal..."));
        characterSoundEffects.Add("butcher shop", Resources.Load<AudioClip>("Sounds/Dr Sott/the butcher shop"));
        characterSoundEffects.Add("public variables...", Resources.Load<AudioClip>("Sounds/Dr Sott/the public variables..."));
        characterSoundEffects.Add("public variables extended", Resources.Load<AudioClip>("Sounds/Dr Sott/scott public variable full less"));
        characterSoundEffects.Add("get this done", Resources.Load<AudioClip>("Sounds/Dr Sott/we gotta get this done"));
        
        Debug.Log("adding Dr Sott's sound files to the dictionary");
    }

    public override bool StartTurn(int currentSkillPointCount) {
        throw new System.NotImplementedException();
    }

    public override void Update() {
        throw new System.NotImplementedException();
    }


    private void Awake() {
        name = "Dr. Sott Leaver (PH.D)";
        currentLeaveChance = 5.0f;
    }
}
