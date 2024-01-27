using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;


public abstract class Passive : MonoBehaviour{
    abstract public void ActivatePassive();
}

public class AdrielPassive : Passive {
    public Character Adriel;
    public Character other;
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
public class DianaPassive : Passive{
    public Character Diana;
    public Character Adriel;
    public Character Michael;
    float healingAmmount = 20.0f;
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
public class MichaelPassive : Passive
{
    public Character Michael;
    public override void ActivatePassive() {
        Michael.canFollowUp = true;
    }
}

public class SottPassive : Passive {
    public Character_DrSottLeaver DrSottLeaver;

    private void useVoiceline() {
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                DrSottLeaver.PlaySound("picking up fish");
                break;
            case 2:
                DrSottLeaver.PlaySound("butcher shop");
                break;
            case 3:
                DrSottLeaver.PlaySound("public variables extended");
                break;
        }
    }
    
    public override void ActivatePassive() {
        useVoiceline();
        
        if (DrSottLeaver.currentLeaveChance < 80.0f) DrSottLeaver.currentLeaveChance += DrSottLeaver.currentLeaveIncrementPerTurn;
        if (!(Random.Range(0.0f, 100.0f) < DrSottLeaver.currentLeaveChance)) return;
        
        DrSottLeaver.hasLeft = true;
        Debug.Log("Sott has left.");
    }
}
