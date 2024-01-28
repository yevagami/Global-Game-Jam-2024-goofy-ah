using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public  BattleManager battleManager;
    public void SetBattleManager(BattleManager bm) { battleManager = bm; } 
    public bool isDead = false;
    //Which team does this character belong to
    public enum Team {
        FRIEND,
        ENEMY
    }; public Team currentTeam;
    
    //public for now (maybe change later?)
    public float currentHealth;
    public float currentEnergy = 20.0f;
    public float maxEnergy = 100.0f;
    public float energyPerTurn = 20.0f;
    public void Heal(float health) { if (currentHealth + health >= baseHealth)  currentHealth += health; }
    public float baseHealth = 100.0f;
    public float currentDefense;
    protected float baseDefense = 20.0f;
    public float currentAttack;

    //portrait
    public Sprite portrait;

    public float GetCurrentAttack() {
        var attack = currentAttack;
        if (isBuffed) attack *= 1.5f;
        if (isAltered) attack *= 1.25f;
        if (isDepressed) attack /= (attack / 5);
        return attack; }
    protected float baseAttack = 20.0f;
    
    //array for debuffs
    public bool isSad, isDepressed, isTaunting;
    public StatusEffect[] statussies;
    public bool canFollowUp;
    public bool isBuffed, isAltered;

    //names for our characters
    public new string name;
    //  sound effects
    protected Dictionary<string, AudioClip> characterSoundEffects;
    protected AudioSource audioSource;

    private void Start() {
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        } //audioSource = GetComponent<AudioSource>();
        
        characterSoundEffects = new Dictionary<string, AudioClip>();
        InitiateSoundEffects();
        
    }

    //  initiate all character sfx to the character sfx dictionary
    protected abstract void InitiateSoundEffects();

    //  play the sound effect at the sound label
    public void PlaySound(string soundLabel) {
        if (characterSoundEffects.TryGetValue(soundLabel, out var clip)) {
            if (audioSource != null) {
                audioSource.clip = clip;
                audioSource.Play();    
            } else {
                Debug.LogWarning("audioSource component not attached"); }
        } else {
            Debug.LogWarning("Sound label '{soundLabel}' not in dictionary"); }
        
    }
    
    abstract public bool StartTurn(int currentSkillPointCount);

    public virtual void TakeDamage(float recievedDamage){
        float damageTaken = 0;
        damageTaken = recievedDamage * (1 - (currentDefense / 100.0f));
        if ((currentHealth -= damageTaken) < 0) {
            currentHealth -= damageTaken;
        }
        else {
            isDead = true;
        }
        
    }

    public virtual void Update() {
        const double TOLERANCE = 5.0;
        if (Math.Abs(currentEnergy - maxEnergy) > TOLERANCE) {
            if (currentEnergy + energyPerTurn > maxEnergy)
                currentEnergy = maxEnergy;
            
            
            currentEnergy += energyPerTurn;
        }
    }

    abstract public void useSkill();
    abstract public void useUltimate();
    abstract public void usePassive();
}
