using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Passive : MonoBehaviour{
    abstract public void ActivatePassive();
}

public class AdrielPassive : Passive {
    public override void ActivatePassive()
    {
        throw new System.NotImplementedException();
    }
}
public class DianaPassive : Passive{
    public override void ActivatePassive()
    {
        throw new System.NotImplementedException();
    }

}
public class MichealPassive : Passive{
    public override void ActivatePassive()
    {
        throw new System.NotImplementedException();
    }

}