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


public abstract class Character : MonoBehaviour {
    //Reference to the gamemode/battle manager
    [SerializeField] private  BattleManager battleManager;
    public void SetBattleManager(BattleManager bm) { battleManager = bm; } 
    public bool isDead = false;

    //Which team does this character belong to
    public enum Team {
        FRIEND,
        ENEMY
    };

    public Team currentTeam;
    //public for now (maybe change later?)
    public float health = 100.0f;
    public float defense = 20.0f;
    public float attack = 15.0f;

    //array for debuffs
    public bool isSad, isDepressed, isTaunting, isDoubting;
    public StatusEffect[] statussies;
    public bool canFollowUp;
    public bool isBuffed, isAltered;

    //  sound effects
    protected Dictionary<string, AudioClip> characterSoundEffects;
    public AudioSource audioSource;

    private void Awake() {
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        } audioSource = GetComponent<AudioSource>();

        
        characterSoundEffects = new Dictionary<string, AudioClip>();
        InitiateSoundEffects();
        
    }


    //  initiate all character sfx to the character sfx dictionary
    protected abstract void InitiateSoundEffects();

    //  play the sound effect at the sound label
    protected void PlaySound(string soundLabel) {
        if (characterSoundEffects.ContainsKey(soundLabel)) {
            if (audioSource != null) {
                audioSource.clip = characterSoundEffects[soundLabel];
                audioSource.Play();    
            } else {
                Debug.Log("audioSource component not attached");
            }
            
        }
        else
        {
            Debug.LogWarning("Sound label '{soundLabel}' not in dictionary");
        }
    }
    
    abstract public bool StartTurn(int currentSkillPointCount);

    public void TakeDamage(float recievedDamage) {
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (defense / 100.0f));
        health -= damageTaken;
    }

    abstract public void Update();
}
