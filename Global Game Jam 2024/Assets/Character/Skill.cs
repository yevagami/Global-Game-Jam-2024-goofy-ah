using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Skill : MonoBehaviour
{
    abstract public void ActivateSkill();
}

public class AdrielSkill : Skill
{
    public Character_Adriel Adriel;

    public override void ActivateSkill()
    {
        if (!Adriel.isTaunting)
        {
            Adriel.isTaunting = true;
            Adriel.currentDefense = Adriel.defenseOnTaunt;
        }
    }
}

public class DianaSkill : Skill
{
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Michael Adriel;

    public override void ActivateSkill()
    {
        //The player needs to choose the other character. Not here 
    }
}

public class MichaelSkill : Skill
{
    public Character_Michael Michael;
    public Character other;


    private void useVoiceline() {
        bool uwu = Michael.isAltered;
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber) {
            case 1:
                if (uwu) Debug.Log("meow");
                else
                {
                }

                break;
            case 2:
                if (uwu) Debug.Log("meow");
                else
                {
                }

                break;
            case 3:
                if (uwu) Debug.Log("meow");
                else
                {
                }

                break;
        }
    }


    public override void ActivateSkill()
    {
        other.TakeDamage(Michael.currentAttack);
        if (Michael.canFollowUp == true)
        {
            System.Random random = new();
            int randomVal = random.Next(2);
            bool result = (randomVal == 1);
            if (result == true) other.TakeDamage(Michael.currentAttack);
        }
    }
}


public class DrSottLeaverAttack : Skill
{
    public Character_DrSottLeaver DrSottLeaver;
    public Character_Adriel adriel;
    public Character_Diana diana;
    public Character_Michael michael;

    private void useVoiceline()
    {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                DrSottLeaver.PlaySound("dont piss me off");
                break;
            case 2:
                DrSottLeaver.PlaySound("get this done");
                break;
            case 3:
                DrSottLeaver.PlaySound("back to work");
                break;
        }
    }

    public override void ActivateSkill()
    {
        useVoiceline();

        adriel.TakeDamage(DrSottLeaver.currentAttack);
        diana.TakeDamage(DrSottLeaver.currentAttack);
        michael.TakeDamage(DrSottLeaver.currentAttack);
    }
}