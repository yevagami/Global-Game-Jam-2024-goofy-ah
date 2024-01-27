using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Test : Character
{
    bool endTurn = false;
    //Override some of the values
    

    public override bool StartTurn(int currentSkillPointCount) {
        if(Input.GetKeyUp(KeyCode.A)) {
            Debug.Log("Character_Test's Turn Has Ended");
            PlaySound("kiriko");
            return false;
        }

        return true;
    }

    public override void Update() {
        return;
    }

    protected override void InitiateSoundEffects() {
        characterSoundEffects.Add("kiriko", Resources.Load<AudioClip>("Sounds/my bike"));
        characterSoundEffects.Add("gyat", Resources.Load<AudioClip>("Sounds/gyat"));
        
    }

    //
    // Start is called before the first frame update
    void Start() {
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
}
