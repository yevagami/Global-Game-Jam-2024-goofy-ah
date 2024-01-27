using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Adriel : Character
{
    bool endTurn = false;
    
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("Adriel's Turn Has Ended");
            return false;
        }

        return true;
    }
    public override void Update()
    {
        return;
    }

    protected override void InitiateSoundEffects()
    {
        
    }

    //
    // Start is called before the first frame update
    void Start()
    {
        name = "Adriel";
    }
}
