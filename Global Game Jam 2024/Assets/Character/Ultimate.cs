using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ultimate : MonoBehaviour
{
    abstract public void UseUltimate();
    // Start is called before the first frame update
 
}

public class AdrielUltimate : Ultimate{

    public override void UseUltimate()
    {
        throw new System.NotImplementedException();
    }
}
public class DianaUltimate : Ultimate
{

    public override void UseUltimate()
    {
        throw new System.NotImplementedException();
    }
}
public class MichealUltimate : Ultimate
{

    public override void UseUltimate()
    {
        throw new System.NotImplementedException();
    }
}