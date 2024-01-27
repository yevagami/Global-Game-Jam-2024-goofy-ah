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
    public Character Diana;
    public Character Michael;
    public Character Adriel;
    public override void UseUltimate()
    {
        Michael.isBuffed = true;
        Adriel.isBuffed = true;
        Diana.TakeDamage();
        throw new System.NotImplementedException();
    }
}
public class MichaelUltimate : Ultimate
{
    public Character Michael;
    float mORE = 50;
    public override void UseUltimate()
    {
        Michael.attackDMG += mORE;
        Michael.isAltered = true;
    }
}