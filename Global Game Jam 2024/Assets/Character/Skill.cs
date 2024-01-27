using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using System;

abstract public class Skill : MonoBehaviour
{
    abstract public void ActivateSkill();
}

public class AdrielSkill : Skill {
    public Character Adriel; 
    public override void ActivateSkill()
    {
        Adriel.isTaunting = true;
        Adriel.defense = 10;
    }
}
public class DianaSkill : Skill
{
    public Character Diana;
    public Character Michael;
    public Character Adriel;
    public override void ActivateSkill()
    {
        //The player needs to choose the other character. Not here 
    }
}
public class MichealSkill : Skill
{
    public Character Michael;
    public Character other;

    public override void ActivateSkill()
    {
        other.TakeDamage();
        if (Michael.canFollowUp == true) {
            System.Random random = new();
            int randomVal = random.Next(2);
            bool result = (randomVal == 1);
            if (result == true) {
                other.TakeDamage();
            }
        }
    }
}