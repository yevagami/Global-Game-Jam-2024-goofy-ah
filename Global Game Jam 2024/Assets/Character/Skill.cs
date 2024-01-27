using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using System;

abstract public class Skill : MonoBehaviour {
    abstract public void ActivateSkill();
}

public class AdrielSkill : Skill {
    public Character_Adriel Adriel; 
    public override void ActivateSkill() {
        if (!Adriel.isTaunting) {
            Adriel.isTaunting = true;
            Adriel.currentDefense = Adriel.defenseOnTaunt;
        }
    }
}
public class DianaSkill : Skill {
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Michael Adriel;
    public override void ActivateSkill()
    {
        //The player needs to choose the other character. Not here 
    }
}
public class MichaelSkill : Skill {
    public Character_Michael Michael;
    public Character other;
    float michaelsAttack = 15.0f;

    public override void ActivateSkill()
    {
        other.TakeDamage(michaelsAttack);
        if (Michael.canFollowUp == true) {
            System.Random random = new();
            int randomVal = random.Next(2);
            bool result = (randomVal == 1);
            if (result == true) {
                other.TakeDamage(michaelsAttack);
            }
        }
    }
}