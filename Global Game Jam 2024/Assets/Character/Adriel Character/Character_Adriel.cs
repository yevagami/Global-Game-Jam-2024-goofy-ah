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
        if (battleManager.skillPoints > 0) {
            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                battleManager.useSkillPoint();
                return (battleManager.textStuff.PrintAnnouncement("Adriel uses Fake Enthusiasm", 1.0f));
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            return false;
        }
        return true;
    }
    
    protected override void InitiateSoundEffects() {
        base.characterSoundEffects.Add("it is what it is...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 1"));   
        base.characterSoundEffects.Add("it is what it is!", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 2"));   
        base.characterSoundEffects.Add("it is what it is.", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 3"));   
        base.characterSoundEffects.Add("shut up.", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 4"));   
        base.characterSoundEffects.Add("the mask...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel Skill1"));   
        base.characterSoundEffects.Add("the mask!", Resources.Load<AudioClip>("Sounds/Adriel/Adriel Skill2"));   
        base.characterSoundEffects.Add("respectfully...", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 5"));   
        base.characterSoundEffects.Add("double giggle", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 6"));   
        base.characterSoundEffects.Add("long giggle", Resources.Load<AudioClip>("Sounds/Adriel/Adriel 7"));   
        

        
        Debug.Log("Adriel has a voice! we're so happy : " + characterSoundEffects.Count);
        
    }
    
    
    
    public override bool PlaySound(string soundLabel) {
        if (characterSoundEffects.ContainsKey(soundLabel)) {
            var clip = characterSoundEffects[soundLabel];
            if (audioSource != null)
            {
                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                    return true;
                }else {
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

    public override void Update()
    {  
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound("it is what it is!");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound("the mask...");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound("the mask!");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound("respectfully...");
        }        
         else if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound("shut up.");
        }

        base.Update();
    }

    public override void useSkill()
    {
        GetComponentInChildren<AdrielSkill>().ActivateSkill();
    }

    public override void useUltimate()
    {
        GetComponentInChildren<AdrielUltimate>().UseUltimate();
    }

    public override void usePassive()
    {
        GetComponentInChildren<AdrielPassive>().ActivatePassive();
    }
}
