using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MichaelPassive : Passive {
    public Character_Michael Michael;
    
    private void Awake() {
        Michael = GetComponent<Character_Michael>();
        if (Michael == null) {
            Debug.LogError("No Michael Reference in Michael Gameplay");
        }
    }
    
    public override void ActivatePassive() {
        Michael.canFollowUp = true;
    }

    
}


public class MichaelSkill : Skill {
    public BattleManager bm;
    public Character_Michael Michael;
    //public Character_DrSottLeaver other;
    public Character enemy;
    
    private void Awake() {
        bm = GetComponentInParent<Character_Michael>().battleManager;
        Michael = bm.GetMichaelCharacter();
        //other = bm.GetOtherCharacter<Character_DrSottLeaver>();
        enemy = bm.GetCharacterByTeam<Character>(Character.Team.ENEMY);
        if (Michael == null || enemy == null) {
            Debug.LogError("No References in Michael Skill Gameplay");
        }
    }
    
    private void useVoiceline() {
        bool uwu = Michael.isAltered;
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                if (uwu) Debug.Log("meow");
                else { }
                break;
            case 2:
                if (uwu) Debug.Log("meow");
                else { }
                break;
            case 3:
                if (uwu) Debug.Log("meow");
                else { }
                break;
        } }
    
    public override void ActivateSkill() {
        useVoiceline();
        enemy.TakeDamage(Michael.GetCurrentAttack());
        if (Michael.canFollowUp == true) {
            System.Random random = new();
            int randomVal = random.Next(2);
            bool result = (randomVal == 1);
            if (result == true) enemy.TakeDamage(Michael.GetCurrentAttack());
        }
    }
}


public class MichaelUltimate : Ultimate
{
    public Character_Michael Michael;
    float attackBoost = 50;

    private void Awake() {
        Michael = GetComponent<Character_Michael>();
        if (Michael == null) {
            Debug.LogError("No Michael Reference in Michael Gameplay");
        }
    }
    
    public override void UseUltimate()
    {
        Michael.currentAttack += attackBoost;
        Michael.isAltered = true;
    }
}

