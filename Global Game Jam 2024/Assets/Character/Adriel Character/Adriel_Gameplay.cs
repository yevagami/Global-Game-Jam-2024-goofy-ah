using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrielPassive : Passive {
    public Character Adriel;
    public Character other;


    private void Awake()
    {
        Adriel = GetComponent<Character_Adriel>();
        if (Adriel == null)
        {
            Debug.LogError("no adriel ref in adriel gameplay");
        }
    }

    public override void ActivatePassive()
    {
        if (!other.isSad)
        {
            other.currentDefense = 0;
        }
        else if (other.isSad && !other.isDepressed)
        {
            other.currentDefense= -1;
        }
        else {
            Debug.Log("Already depressed");
        }
    }
}


public class AdrielSkill : Skill
{
    public Character_Adriel Adriel;

    private void Awake()
    {
        Adriel = GetComponent<Character_Adriel>();
        if (Adriel == null)
        {
            Debug.LogError("no adriel ref in adriel gameplay");
        }
    }
    
    public override void ActivateSkill()
    {
        if (!Adriel.isTaunting)
        {
            Adriel.isTaunting = true;
            Adriel.currentDefense = Adriel.defenseOnTaunt;
        }
    }
}

public class AdrielUltimate : Ultimate {
    public Character other;

    
    public override void UseUltimate()
    {
        other.isDepressed = true;
    }
}

