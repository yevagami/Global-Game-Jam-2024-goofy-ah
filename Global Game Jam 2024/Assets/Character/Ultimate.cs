using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ultimate : MonoBehaviour
{
    abstract public void UseUltimate();
    // Start is called before the first frame update
 
}

public class AdrielUltimate : Ultimate{
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
    float mORE = 50;
    public override void UseUltimate()
    {
        Michael.currentAttack += mORE;
        Michael.isAltered = true;
    }
}