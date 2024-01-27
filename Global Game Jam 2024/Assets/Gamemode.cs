using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{
    
    
    
    
}

public class TurnManager : MonoBehaviour
{
    //  create a new list to hold all player characters
    public List<Character> playerCharacters = new();
    //  holds the reference to the current enemyCharacter on field
    public Character enemyCharacter;

    private int currentCharacterIndex = 0;
    private int turnCounter = 1;
    
    private void Awake() {
        StartNextTurn();
    }

    private bool IsGameOver() {
        //  blah blah blah put good code here,
        //  do I look like a progarmmer to you?
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
        }else {
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
        currentPlayer.StartTurn();  //  needs to be implemented in the character classes
        currentCharacterIndex++;
    }

    private void EnemyTurn() {
        enemyCharacter.StartTurn(); //  same with player, unimplemented
    }
    
    
}
