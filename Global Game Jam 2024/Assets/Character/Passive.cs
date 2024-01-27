using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


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
    public Character_DrSottLeaver Sott;

    public override void ActivatePassive() {
        if ((Sott.currentLeaveChance < 80.0f)) Sott.currentLeaveChance += Sott.currentLeaveIncrementPerTurn;
        
        if (Random.Range(0.0f, 100.0f) < Sott.currentLeaveChance) {
            Debug.Log("Sott has left.");
        }
    }

}
