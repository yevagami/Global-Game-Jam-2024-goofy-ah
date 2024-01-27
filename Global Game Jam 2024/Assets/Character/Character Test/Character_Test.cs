using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Test : Character
{
    //Override some of the values
    public override bool StartTurn(int currentSkillPointCount) {
        throw new System.NotImplementedException();
    }

    public override void Update() {
        return;
    }

    //
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
