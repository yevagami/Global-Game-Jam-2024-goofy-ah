using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaPassive : Passive {
    public BattleManager bm;
    public Character_Diana Diana;
    public Character_Adriel Adriel;
    public Character_Michael Michael;
    float healingAmmount = 20.0f;

    private void Awake() {
        bm = GetComponentInParent<Character_Diana>().battleManager;
        
        if (bm == null) {
            Debug.LogError("no bm ref snatched from component parent"); return;
        }
        Diana = bm.GetDianaCharacter();
        Michael = bm.GetMichaelCharacter();
        Adriel = bm.GetAdrielCharacter();
        if (Diana == null || Adriel == null || Michael == null) Debug.LogError("No refs in Diana Skill Gameplay");
    }

    public override void ActivatePassive()
    {
        if (Michael.currentHealth < Adriel.currentHealth && Michael.currentHealth < Diana.currentHealth)
        {
            Michael.currentHealth += healingAmmount;
        }
        else if (Adriel.currentHealth < Michael.currentHealth  && Adriel.currentHealth < Diana.currentHealth) {
            Adriel.currentHealth += healingAmmount;
        }
        else{
            Diana.currentHealth += healingAmmount;
        }
    }

}

public class DianaSkill : Skill {
    public BattleManager bm;
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;
    public Character other;
    
    private void Awake() {
        bm = GetComponentInParent<Character_Diana>().battleManager;
        
        if (bm == null) {
            Debug.LogError("no bm ref snatched from component parent"); return;
        }
        Diana = bm.GetDianaCharacter();
        Michael = bm.GetMichaelCharacter();
        Adriel = bm.GetAdrielCharacter();
        other = bm.GetCharacterByTeam<Character>(Character.Team.ENEMY);
        if (Diana == null || Adriel == null || Michael == null) Debug.LogError("No refs in Diana Skill Gameplay");
    }
    
    public override void ActivateSkill() {
        var damageDealt = Diana.currentAttack / 1.25f;
        other.TakeDamage(damageDealt);
        Diana.Heal(damageDealt);        
    }
}


public class DianaUltimate : Ultimate {
    public BattleManager bm;
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;

    private void Awake() {
        bm = GetComponentInParent<Character_Diana>().battleManager;
        
        if (bm == null) {
            Debug.LogError("no bm ref snatched from component parent"); return;
        }
        Diana = bm.GetDianaCharacter();
        Michael = bm.GetMichaelCharacter();
        Adriel = bm.GetAdrielCharacter();
        if (Diana == null || Adriel == null || Michael == null) Debug.LogError("No refs in Diana Skill Gameplay");
    }
    
    public override void UseUltimate() {
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage(45.0f);
    }
}
