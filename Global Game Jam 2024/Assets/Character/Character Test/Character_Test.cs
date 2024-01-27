using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Test : Character
{
    //Override some of the values
    public override bool StartTurn(int currentSkillPointCount) {
        Debug.Log("Character_Test's Turn");
        if(Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Character_Test's Turn Has Ended");
            return false;
        }

        return true;
    }

    public override void Update() {
        throw new System.NotImplementedException();
    }

    //
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
