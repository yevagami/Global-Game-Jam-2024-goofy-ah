using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_DrSottLeaver : Character {
    //  Logic-based variables
    public bool hasLeft = false;
    public float currentLeaveChance = 5.0f;
    public float currentLeaveIncrementPerTurn = 5.0f;

    //  Sott's stats
    private float bossDefense = 35.0f;
    private float bossAttack = 30.0f;
    private float bossHP = 200.0f;
    
    
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
        int action = Random.Range(0, 4);
        List<Character> playerList = battleManager.GetParticipants();

        if(action > 2) {
            for (int i = 0; i < playerList.Count; i++) {
                if (playerList[i].currentTeam == Team.FRIEND) {
                    playerList[i].TakeDamage(10.0f);
                }
            }
            return (battleManager.textStuff.PrintAnnouncement("Dr. Sott Unleashes A Deadly attack", 1.0f));
        } else {
            return (battleManager.textStuff.PrintAnnouncement("Dr. Sott Attempts to leave", 1.0f));
        }
    }

    
    public override bool PlaySound(string soundLabel)
    {
        if (characterSoundEffects.ContainsKey(soundLabel))
        {
            var clip = characterSoundEffects[soundLabel];
            if (audioSource != null)
            {
                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                    return true;
                }
                else
                {
                    Debug.LogWarning($"Audio clip for sound label '{soundLabel}' is null");
                }
            }
            else
            {
                Debug.LogWarning("audioSource component not attached");
            }
        }
        else
        {
            Debug.LogWarning($"Sound label '{soundLabel}' not in dictionary");
        }

        return false;
    }

    
    
    public override void TakeDamage(float recievedDamage)
    {
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (currentDefense / 100.0f));
        if ((currentHealth -= damageTaken) < 0)
        {
            currentHealth -= damageTaken;
        } else {
            isDead = true;
        }
    }


    private void Awake() {
        name = "Dr. Sott Leaver (PH.D)";
        currentAttack = bossAttack;
        currentHealth = bossHP;
        currentDefense = bossDefense;
    }

    public override void useSkill()
    {
        GetComponentInChildren<DrSottLeaverAttack>().ActivateSkill();
    }
    private void useUltimateVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                PlaySound("public variables...");
                break;
            case 2:
                PlaySound("public variables extended");
                break;
        }
    }
    public override void useUltimate()
    {
        useUltimateVoiceline();
        GetComponentInChildren<DrSottLeaverUltimate>().UseUltimate();
    }

    public override void usePassive()
    {
        GetComponentInChildren<SottPassive>().ActivatePassive();
    }
}
