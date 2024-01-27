using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : Character
{
   

    public override bool StartTurn(int currentSkillPointCount) {
        int randomValue = Random.Range(0, 5);
        Debug.Log("===============");
        if(randomValue == 0) {
            Debug.Log("Enemy Attack hit");
            Debug.Log("===============");
            return false;

        } else {
            Debug.Log("Enemy Attack Missed");
            Debug.Log("===============");
            return false;
        }
    }

    public override void Update() {
        return;
    }

    protected override void InitiateSoundEffects() {
        return;
    }
}
