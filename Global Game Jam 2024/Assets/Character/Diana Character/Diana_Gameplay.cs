
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DianaPassive : Passive {
    public BattleManager bmPassive;
    public Character_Diana Diana;
    public Character_Adriel Adriel;
    public Character_Michael Michael;
    float healingAmmount = 20.0f;

    private void Awake() {
        //bm = GetComponentInParent<Character_Diana>().battleManager;
        if (bmPassive == null) { Debug.LogWarning("no bm ref snatched from component parent"); return; }
        
        Diana = bmPassive.GetDianaCharacter();
        Michael = bmPassive.GetMichaelCharacter();
        Adriel = bmPassive.GetAdrielCharacter();
        if (Diana == null || Adriel == null || Michael == null) Debug.LogWarning("No refs in Diana Passive Gameplay");
    }

    public override void ActivatePassive() {
        if (Michael.currentHealth < Adriel.currentHealth && Michael.currentHealth < Diana.currentHealth) {
            Diana.PlaySound("a little bit for you!~");
            Michael.currentHealth += healingAmmount;
        }else if (Adriel.currentHealth < Michael.currentHealth  && Adriel.currentHealth < Diana.currentHealth) {
            Adriel.currentHealth += healingAmmount;
            Diana.PlaySound("a little bit for you~");
        }else{
            Diana.currentHealth += healingAmmount;
            Diana.PlaySound("a little bit for you!");
        }
    }

}

public class DianaSkill : Skill {
    public BattleManager bmSkill;
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;
    public Character other;
    
    private void Awake() {
        //bm = GetComponentInParent<Character_Diana>().battleManager;
        
        if (bmSkill == null) {
            Debug.LogWarning("no bm ref snatched from component parent"); return;
        }
        Diana = bmSkill.GetDianaCharacter();
        Michael = bmSkill.GetMichaelCharacter();
        Adriel = bmSkill.GetAdrielCharacter();
        other = bmSkill.GetCharacterByTeam<Character>(Character.Team.ENEMY);
        if (Diana == null || Adriel == null || Michael == null) Debug.LogWarning("No refs in Diana Skill Gameplay");
    }

    void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                Diana.PlaySound("it IS about me");
                break;
            case 2:
                Diana.PlaySound("it IS about ME");
                break;
        }
        
    }
    
    public override void ActivateSkill() {
        var damageDealt = Diana.currentAttack / 1.25f;
        other.TakeDamage(damageDealt);
        Diana.Heal(damageDealt);
        useVoiceline();
    }
}


public class DianaUltimate : Ultimate {
    public BattleManager bmUlt;
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;

    private void Awake() {
        //bm = GetComponentInParent<Character_Diana>().battleManager;
        if (bmUlt == null) {
            Debug.LogWarning("no bm ref snatched from component parent"); return;
        }
        Diana = bmUlt.GetDianaCharacter();
        Michael = bmUlt.GetMichaelCharacter();
        Adriel = bmUlt.GetAdrielCharacter();
        if (Diana == null || Adriel == null || Michael == null) Debug.LogWarning("No refs in Diana Ultimate Gameplay");
    }

    void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber) {
            case 1:
                Diana.PlaySound("come on guys");
                break;
            case 2:
                Diana.PlaySound("come on guys!~");
                break;
        }
    }
    
    public override void UseUltimate() {
        useVoiceline();
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage(45.0f);
    }
}


