using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Michael : Character
{

    bool endTurn = false;

    // ReSharper disable Unity.PerformanceAnalysis
    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKey(KeyCode.M))
        {
            Debug.Log("Michael's Turn Has Ended");
            return false;
        }
        return true;
    }

    private void Awake() {
        name = "Michael";
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        baseAttack = 25.0f; currentAttack = baseAttack;
    }

    public override void Update()
    {
        return;
    }
    private void useVoiceline() {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                PlaySound(isAltered ? "nya~" : "that hurt");
                break;
            case 2:
                PlaySound(isAltered ? "meow~" : "dont like pain");
                break;
            case 3:
                PlaySound(isAltered ? "nya~" : "UGH");
                break;
        } }
    public override void TakeDamage(float recievedDamage) {
        useVoiceline();
        base.TakeDamage(recievedDamage);
    }

    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("got out of here", Resources.Load<AudioClip>("Sounds/Michael/Michael 1"));
        characterSoundEffects.Add("got a little closer", Resources.Load<AudioClip>("Sounds/Michael/Michael 2"));
        characterSoundEffects.Add("more time together", Resources.Load<AudioClip>("Sounds/Michael/Michael 3"));
        characterSoundEffects.Add("cuddled~", Resources.Load<AudioClip>("Sounds/Michael/Michael 4"));
        characterSoundEffects.Add("bbg~", Resources.Load<AudioClip>("Sounds/Michael/Michael 5"));
        characterSoundEffects.Add("pick me extended", Resources.Load<AudioClip>("Sounds/Michael/Michael 8"));    
        characterSoundEffects.Add("pick me love me", Resources.Load<AudioClip>("Sounds/Michael/Michael 9"));    
        characterSoundEffects.Add("that hurt", Resources.Load<AudioClip>("Sounds/Michael/Michael 11"));    
        characterSoundEffects.Add("dont like pain", Resources.Load<AudioClip>("Sounds/Michael/Michael 12"));    
        characterSoundEffects.Add("nya~", Resources.Load<AudioClip>("Sounds/Michael/Michael 14"));    
        characterSoundEffects.Add("meow~", Resources.Load<AudioClip>("Sounds/Michael/Michael 15"));    
        characterSoundEffects.Add("UGH", Resources.Load<AudioClip>("Sounds/Michael/Michael 16"));    
        
        Debug.Log("adding Michael's sound files to the dictionary");
    }

    public override void useSkill()
    {
        
    }

    public override void useUltimate()
    {
        throw new NotImplementedException();
    }

    public override void usePassive()
    {
        throw new NotImplementedException();
    }
}
