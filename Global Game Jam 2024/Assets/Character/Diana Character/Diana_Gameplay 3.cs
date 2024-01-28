using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    
    public override void UseUltimate() {
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage(45.0f);
    }
}
