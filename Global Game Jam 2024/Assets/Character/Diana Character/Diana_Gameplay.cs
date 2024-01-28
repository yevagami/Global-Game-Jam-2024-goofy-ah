
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    
    public override void ActivateSkill() {
        var damageDealt = Diana.currentAttack / 1.25f;
        other.TakeDamage(damageDealt);
        Diana.Heal(damageDealt);        
    }
}

