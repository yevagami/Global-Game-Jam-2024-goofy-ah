using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class Character_Michael : Character {
=======
public class Character_Michael : Character
{

>>>>>>> Stashed changes
    bool endTurn = false;

    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("Michael's Turn Has Ended");
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
        return;
    }

    //
    // Start is called before the first frame update
    void Start()
    {
        name = "Michael";
    }
}
