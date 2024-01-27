using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour {
}

public class TurnManager : MonoBehaviour {
    //  create a new list to hold all player characters
    public List<Character> participants = new();

    public int skillPoints;

    private bool skipCurrentTurn = false;

    private int currentCharacterIndex = 0;
    private int turnCounter = 0;

    private void Awake()
    {
        skillPoints = 3; // start with 3 skill points
        StartNextTurn();
    }

    private bool IsGameOver()
    {
        //  blah blah blah put good code here,
        //  do I look like a progarmmer to you?
        return false;
    }

    private bool ShouldSkippidi(Character character) {
        //  connected to user interface elements that do stuff/keybind inputs
        //  rn it just returns false. NO SKIPPING.
        return false;
    }

    private void StartNextTurn() {
        if (IsGameOver()) {
            Debug.Log("Game is over!");
            return;
        }
        //  increment the turn counter
        turnCounter++;
        //  repeat (recursion)
        StartNextTurn();
    }

}