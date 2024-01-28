using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
