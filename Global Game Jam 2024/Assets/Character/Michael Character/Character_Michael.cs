using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character_Michael : Character {
    bool endTurn = false;

    // ReSharper disable Unity.PerformanceAnalysis
    public override bool PlaySound(string soundLabel) {
        if (characterSoundEffects.ContainsKey(soundLabel)) {
            var clip = characterSoundEffects[soundLabel];
            if (audioSource != null) {
                if (clip != null) {
                    audioSource.clip = clip;
                    audioSource.Play();
                    return true;
                }else {
                    Debug.LogWarning($"Audio clip for sound label '{soundLabel}' is null");
                }
            }else {
                Debug.LogWarning("audioSource component not attached");
            }
        }else {
            Debug.LogWarning($"Sound label '{soundLabel}' not in dictionary");
        }

        return false;
    }
    

    public override bool StartTurn(int currentSkillPointCount)
    {
        if(battleManager.skillPoints > 0) {
            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                battleManager.useSkillPoint();

                //Find scott and deal damage to him
                //List<Character> playerList = battleManager.GetParticipants();
                //for (int i = 0; i < playerList.Count; i++) {
                //    if (playerList[i].currentTeam == Team.ENEMY) {
                //        playerList[i].TakeDamage();
                //    }
                //}

                return (battleManager.textStuff.PrintAnnouncement("Michael uses The Yappening", 1.0f));
            }

            
        }
                      
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            return false;
        }

        return true;
    }

    private void Awake()
    {
        name = "Michael";
        currentHealth = baseHealth;
        currentDefense = baseDefense;
        baseAttack = 25.0f;
        currentAttack = baseAttack;
    }

    private bool useDamagedVoiceline() {
        switch (Random.Range(1, 4)) {
            case 1:
                PlaySound(isAltered ? "nya~" : "that hurt");
                return true;
            case 2:
                PlaySound(isAltered ? "meow~" : "dont like pain");
                return true;
            case 3:
                PlaySound(isAltered ? "nya~" : "UGH");
                return true;
        }

        return false;
    }

    public override void TakeDamage(float recievedDamage) {
        if (useDamagedVoiceline()) { Debug.Log("ouchers"); }
        base.TakeDamage(recievedDamage);
    }

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlaySound("got a little closer");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            PlaySound("more time together");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PlaySound("dont like pain");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            PlaySound("pick me extended");
        }        
        else if (Input.GetKeyDown(KeyCode.B))
        {
            PlaySound("pick me love me");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            PlaySound("bbg~");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            PlaySound("nya~");
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            PlaySound("meow~");
        }
        
        
        base.Update();
    }
    protected override void InitiateSoundEffects() {
        
        characterSoundEffects.Add("got out of here", Resources.Load<AudioClip>("Sounds/Michael/Michael 8"));
        characterSoundEffects.Add("got a little closer", Resources.Load<AudioClip>("Sounds/Michael/Michael 9"));
        characterSoundEffects.Add("more time together", Resources.Load<AudioClip>("Sounds/Michael/Michael 13"));
        characterSoundEffects.Add("cuddled~", Resources.Load<AudioClip>("Sounds/Michael/Michael 11"));
        characterSoundEffects.Add("bbg~", Resources.Load<AudioClip>("Sounds/Michael/Michael 12"));
        characterSoundEffects.Add("pick me extended", Resources.Load<AudioClip>("Sounds/Michael/Michael 1"));
        characterSoundEffects.Add("pick me love me", Resources.Load<AudioClip>("Sounds/Michael/Michael 2"));
        characterSoundEffects.Add("that hurt", Resources.Load<AudioClip>("Sounds/Michael/Michael 3"));
        characterSoundEffects.Add("dont like pain", Resources.Load<AudioClip>("Sounds/Michael/Michael 4"));
        characterSoundEffects.Add("nya~", Resources.Load<AudioClip>("Sounds/Michael/Michael 5"));
        characterSoundEffects.Add("meow~", Resources.Load<AudioClip>("Sounds/Michael/Michael 6"));
        characterSoundEffects.Add("UGH", Resources.Load<AudioClip>("Sounds/Michael/Michael 7"));

        Debug.Log("adding Michael's sound files to the dictionary");
    }

    public void useSkillVoiceline()
    {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                PlaySound(isAltered ? "cuddled~" : "got out of here");
                break;
            case 2:
                PlaySound(isAltered ? "bbg~" : "got a little closer");
                break;
            case 3:
                PlaySound(isAltered ? "cuddled~" : "more time together");
                break;
        }
    }

    public override void useSkill()
    {
        useSkillVoiceline();
        GetComponentInChildren<MichaelSkill>().ActivateSkill();
    }

    public void useUltimateVoiceline()
    {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:
                PlaySound("pick me extended");
                break;
            case 2:
                PlaySound("pick me love me");
                break;
        }
    }

    public override void useUltimate()
    {
        useUltimateVoiceline();
        GetComponentInChildren<MichaelUltimate>().UseUltimate();
    }

    public override void usePassive()
    {
        GetComponentInChildren<MichaelPassive>().ActivatePassive();
    }
}