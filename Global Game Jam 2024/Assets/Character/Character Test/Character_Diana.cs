using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Diana : Character
{
    bool endTurn = false;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    
    public override bool StartTurn(int currentSkillPointCount)
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("Diana's Turn Has Ended");
            return false;
        }

        return true;
    }

    public override void Update()
    {
        return;
    }

<<<<<<< Updated upstream
    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("Talent", Resources.Load<AudioClip>("Sounds/talentSoundDiana.ogg"));
        characterSoundEffects.Add("Skill", Resources.Load<AudioClip>("Sounds/skillSoundDiana.ogg"));
        characterSoundEffects.Add("Ultimate", Resources.Load<AudioClip>("Sounds/talentSoundDiana.ogg"));
=======
    protected override void InitiateSoundEffects()
    {
        return;
    }

    //
    // Start is called before the first frame update
    void Start()
    {
        name = "Diana";
>>>>>>> Stashed changes
    }
}