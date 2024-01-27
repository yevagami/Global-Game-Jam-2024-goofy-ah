using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
///     PASSIVE ABILITY
/// </summary>
public class SottPassive : Passive {
    public Character_DrSottLeaver DrSottLeaver;

    private void Awake() {
        DrSottLeaver = GetComponent<Character_DrSottLeaver>();
        if (DrSottLeaver == null) {
            Debug.LogError("No Sott in DrScott Gameplay");
        }
    }

    private void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("picking up fish");
                break;
            case 2:
                DrSottLeaver.PlaySound("butcher shop");
                break;
        }
    }
    
    public override void ActivatePassive() {
        useVoiceline();
        
        if (DrSottLeaver.currentLeaveChance < 80.0f) DrSottLeaver.currentLeaveChance += DrSottLeaver.currentLeaveIncrementPerTurn;
        if (!(Random.Range(0.0f, 100.0f) < DrSottLeaver.currentLeaveChance)) return;
        
        DrSottLeaver.hasLeft = true;
        Debug.Log("Sott has left.");
    }
}

/// <summary>
///     ACTIVE SKILL
/// </summary>
public class DrSottLeaverAttack : Skill {
    public Character_DrSottLeaver DrSottLeaver;
    public Character_Adriel adriel;
    public Character_Diana diana;
    public Character_Michael michael;

    private void Awake()
    {
        DrSottLeaver = GetComponent<Character_DrSottLeaver>();
        if (DrSottLeaver == null)
        {
            Debug.LogError("No Sott in DrScott Gameplay");
        }
    }
    
    private void useVoiceline() {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("dont piss me off");
                break;
            case 2:
                DrSottLeaver.PlaySound("get this done");
                break;
            case 3:
                DrSottLeaver.PlaySound("back to work");
                break; 
        }
    }

    public override void ActivateSkill() {
        useVoiceline();

        adriel.TakeDamage(DrSottLeaver.GetCurrentAttack());
        diana.TakeDamage(DrSottLeaver.GetCurrentAttack());
        michael.TakeDamage(DrSottLeaver.GetCurrentAttack());
    }
}


/// <summary>
///     Ultimate Ability
/// </summary>
public class DrSottLeaverUltimate : Ultimate {
    public BattleManager bm;
    public Character_DrSottLeaver DrSottLeaver;

    private void Awake() {
        bm = GetComponentInParent<Character_DrSottLeaver>().battleManager;
        if (bm == null) {
            Debug.LogError("No BATTLe MANAGER in DrScott Gameplay");
            return;
        }
        DrSottLeaver = bm.GetOtherCharacter<Character_DrSottLeaver>();
        if (DrSottLeaver == null) Debug.LogError("No Sott in DrScott Gameplay");
    }
    
    private void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                DrSottLeaver.PlaySound("public variables...");
                break;
            case 2:
                DrSottLeaver.PlaySound("public variables extended");
                break;
        }
    }

    //  "Sets to Public" (makes us attack eachother)
    public override void UseUltimate() {
        useVoiceline();
        
        bm.GetDianaCharacter().currentTeam = Character.Team.ENEMY;
        bm.GetMichaelCharacter().currentTeam = Character.Team.ENEMY;
        bm.GetAdrielCharacter().currentTeam = Character.Team.ENEMY;

        //  idk if this works, coroutines are goofy no ahh
        StartCoroutine(RevertTeamsAfterDelay());
    }
    
    private IEnumerator RevertTeamsAfterDelay() {
        int initialTurnIndex = bm.currentTurnIndex;

        while (bm.currentTurnIndex == initialTurnIndex) {
            yield return null; 
        }
        //  revert back
        bm.GetDianaCharacter().currentTeam = Character.Team.FRIEND;
        bm.GetMichaelCharacter().currentTeam = Character.Team.FRIEND;
        bm.GetAdrielCharacter().currentTeam = Character.Team.FRIEND;
    }
    
    
}