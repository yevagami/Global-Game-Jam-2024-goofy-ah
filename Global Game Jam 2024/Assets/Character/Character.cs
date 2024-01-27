using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class StatusEffect : MonoBehaviour
{
    abstract public void ApplyStatus();
}

public class StatusDepressed : StatusEffect
{
    public override void ApplyStatus()
    {
        Debug.Log("YOu are depressed");
    }
}


public abstract class Character : MonoBehaviour
{
    //Reference to the gamemode/battle manager
    public BattleManager GameMaster;
    public bool isDead = false;

    //Which team does this character belong to
    public enum Team
    {
        FRIEND,
        ENEMY
    };

    public Team currentTeam;

    //public for now (maybe change later?)
    public float health = 100.0f;
    public float defense = 20.0f;
    public float attack = 15.0f;

    //array for debuffs
    public bool isSad, isDepressed, isTaunting, isTaunted, isDoubting;

    public StatusEffect[] statussies;
    public bool canFollowUp;

    public bool isBuffed, isAltered;

    //passive, attack, ultimate
    //actions: attack, heal, 


    //  sound effects
    protected Dictionary<string, AudioClip> characterSoundEffects;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        characterSoundEffects = new();
        InitiateSoundEffects();
    }


    //  initiate all character sfx to the character sfx dictionary
    protected abstract void InitiateSoundEffects();

    //  play the sound effect at the sound label
    protected void PlaySound(string soundLabel)
    {
        if (characterSoundEffects.ContainsKey(soundLabel))
        {
            audioSource.clip = characterSoundEffects[soundLabel];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound label '{soundLabel}' not in dictionary");
        }
    }

    abstract public bool StartTurn(int currentSkillPointCount);

    public void TakeDamage(float recievedDamage)
    {
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (defense / 100.0f));
        health -= damageTaken;
    }

    abstract public void Update();
}

public class CharacterAdriel : Character
{
    protected override void InitiateSoundEffects()
    {
        throw new NotImplementedException();
    }

    public override bool StartTurn(int currentSkillPointCount)
    {
        if (currentSkillPointCount != 0) return true;

        Debug.Log("NO SKILLPOINTS! you whore.");
        return false;
    }

    public override void Update()
    {
    }
}