using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Ultimate : MonoBehaviour
{
    abstract public void UseUltimate();
    // Start is called before the first frame update
}

public class AdrielUltimate : Ultimate
{
    public Character other;

    public override void UseUltimate()
    {
        other.isDepressed = true;
    }
}

public class DianaUltimate : Ultimate
{
    public Character_Diana Diana;
    public Character_Michael Michael;
    public Character_Adriel Adriel;

    public override void UseUltimate()
    {
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage(45.0f);
    }
}

public class MichaelUltimate : Ultimate
{
    public Character_Michael Michael;
    float attackBoost = 50;

    public override void UseUltimate()
    {
        Michael.currentAttack += attackBoost;
        Michael.isAltered = true;
    }
}

public class DrSottLeaverUltimate : Ultimate
{
    public Character_DrSottLeaver DrSottLeaver;

    private void useVoiceline() {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:
                DrSottLeaver.PlaySound("public variables...");
                break;
            case 2:
                DrSottLeaver.PlaySound("public variables extended");
                break;
        }
    }

    //  "Sets to Public"
    public override void UseUltimate() {
        useVoiceline();


        
        //  LOGIC HERE
    }
}