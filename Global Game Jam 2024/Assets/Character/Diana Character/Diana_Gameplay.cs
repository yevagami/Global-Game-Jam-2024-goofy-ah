using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaPassive : Passive{
    public Character Diana;
    public Character Adriel;
    public Character Michael;
    float healingAmmount = 20.0f;

    private void Awake()
    {
        Diana = GetComponent<Character_Diana>();
        if (Diana == null)
        {
            Debug.LogError("No diana ref in Diana Gameplay");
        }
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

public class DianaSkill : Skill
{
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Michael Adriel;

    private void Awake()
    {
        Diana = GetComponent<Character_Diana>();
        if (Diana == null)
        {
            Debug.LogError("No diana ref in Diana Gameplay");
        }
    }
    
    public override void ActivateSkill()
    {
        //The player needs to choose the other character. Not here 
    }
}


public class DianaUltimate : Ultimate
{
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;

    private void Awake()
    {
        Diana = GetComponent<Character_Diana>();
        if (Diana == null)
        {
            Debug.LogError("No diana ref in Diana Gameplay");
        }
    }
    
    public override void UseUltimate()
    {
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage(45.0f);
    }
}
