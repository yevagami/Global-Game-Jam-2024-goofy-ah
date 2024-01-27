using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            other.defense = 0;
        }
        else if (other.isSad && !other.isDepressed)
        {
            other.defense = -1;
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
        if (Michael.health < Adriel.health && Michael.health < Diana.health)
        {
            Michael.health += healingAmmount;
        }
        else if (Adriel.health < Michael.health && Adriel.health < Diana.health) {
            Adriel.health += healingAmmount;
        }
        else{
            Diana.health += healingAmmount;
        }
    }

}
public class MichaelPassive : Passive
{
    public Character Michael;
    public override void ActivatePassive()
    {

        Michael.canFollowUp = true;

    }
}