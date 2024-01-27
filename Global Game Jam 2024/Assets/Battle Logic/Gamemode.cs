using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour {
}

public class TurnManager : MonoBehaviour {
    //  create a new list to hold all player characters
    public List<Character> playerCharacters = new();

    //  holds the reference to the current enemyCharacter on field
    public Character enemyCharacter;

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

        //  have all players taken their turn?
        if (currentCharacterIndex >= playerCharacters.Count) {
            //  reset the index
            currentCharacterIndex = 0;
            //  enemy takes their turn
            EnemyTurn();
        } else {
            //  otherwise its the players turn
            PlayerTurn();
        }
        //  increment the turn counter
        turnCounter++;
        //  repeat (recursion)
        StartNextTurn();
    }

    private void PlayerTurn() {
        Character currentPlayer = playerCharacters[currentCharacterIndex];
        skipCurrentTurn = ShouldSkippidi(currentPlayer);

        if (!skipCurrentTurn) {
            int newSkillPointCount = currentPlayer.StartTurn(skillPoints);
            currentCharacterIndex++;
            skillPoints = newSkillPointCount;
        }
    }

    private void EnemyTurn() {
        //  enemy always has a skillpoint, so i hard set it to 1.
        // he'll do his turns differently (rng to skip or not)
        enemyCharacter.StartTurn(1); //  same with player, unimplemented
    }
}