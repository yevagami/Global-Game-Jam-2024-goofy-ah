using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Diana : Character
{
    bool endTurn = false;

    
    
    
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

    
    public override bool StartTurn(int currentSkillPointCount) {
        if (battleManager.skillPoints > 0) {
            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                battleManager.useSkillPoint();
                return (battleManager.textStuff.PrintAnnouncement("Diana uses Cheerlead", 1.0f));
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            return false;
        }

        return true;
    }

    public override void usePassive()
    {
        GetComponentInChildren<DianaPassive>().ActivatePassive();
    }

    public override void useSkill()
    {
        GetComponentInChildren<DianaSkill>().ActivateSkill();
    }

    public override void useUltimate()
    {
        GetComponentInChildren<DianaUltimate>().UseUltimate();
    }

    void useOuchieVoiceline()
    {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
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

    public override void TakeDamage(float recievedDamage)
    {
        useOuchieVoiceline();

        base.TakeDamage(recievedDamage);
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

    protected override void InitiateSoundEffects()
    {
        characterSoundEffects.Add("a little bit for you!", Resources.Load<AudioClip>("Sounds/Diana/Diana 1")); 
        characterSoundEffects.Add("a little bit for you~", Resources.Load<AudioClip>("Sounds/Diana/Diana 2"));//
        characterSoundEffects.Add("a little bit for you!~", Resources.Load<AudioClip>("Sounds/Diana/Diana 3"));//
        characterSoundEffects.Add("it IS about me", Resources.Load<AudioClip>("Sounds/Diana/Diana 4"));
        characterSoundEffects.Add("it IS about ME", Resources.Load<AudioClip>("Sounds/Diana/Diana 5"));//
        characterSoundEffects.Add("come on guys", Resources.Load<AudioClip>("Sounds/Diana/Diana 6"));
        characterSoundEffects.Add("come on guys!~", Resources.Load<AudioClip>("Sounds/Diana/Diana 7"));//
        characterSoundEffects.Add("son of a birch", Resources.Load<AudioClip>("Sounds/Diana/Diana 8"));//
        characterSoundEffects.Add("i dont like that...", Resources.Load<AudioClip>("Sounds/Diana/Diana 9"));
        characterSoundEffects.Add("heyy", Resources.Load<AudioClip>("Sounds/Diana/Diana 12"));//

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