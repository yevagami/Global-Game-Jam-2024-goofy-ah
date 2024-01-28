using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    //public TextChange changer;
    [SerializeField] GameManager manager;

    //public TextChange battleStats;
    //For the sake of testing
    public List<GameObject> characterObjects = new List<GameObject>();
    List<Character> participants = new List<Character>();
    public List<Character> GetParticipants() { return participants; }

    //  returns Diana's Character
    public Character_Diana GetDianaCharacter() {
        return GetCharacterByTeam<Character_Diana>(Character.Team.FRIEND, "Diana");
    } 
    //  returns Michael's Character
    public Character_Michael GetMichaelCharacter() {
        return GetCharacterByTeam<Character_Michael>(Character.Team.FRIEND, "Michael");
    }
    //  returns Adriel's Chracter
    public Character_Adriel GetAdrielCharacter() {
        return GetCharacterByTeam<Character_Adriel>(Character.Team.FRIEND, "Adriel");
    }

    public T GetOtherCharacter<T>() where T : Character {
        List<T> matchingCharacters = new();
        
        foreach (Character character in participants) {
            if (character is T && character != null) 
                matchingCharacters.Add((T)character);
        }
        if (matchingCharacters.Count > 0) {
            return matchingCharacters[Random.Range(0, matchingCharacters.Count)];
        }

        return null; // return null if nothing
    }
    
    
    //  returns a Character's child type based off their team and the name
    public T GetCharacterByTeam<T>(Character.Team team, string characterName = null) where T : Character {
        List<T> matchingCharacters = new();

        foreach (Character character in participants) {
            if (character is T && character.currentTeam == team) {
                T typedCharacter = (T)character;
                if (string.IsNullOrEmpty(characterName) || character.gameObject.name == characterName) 
                    return typedCharacter; //   return the exact character
                matchingCharacters.Add(typedCharacter);
            } }
        if (matchingCharacters.Count > 0)
            return matchingCharacters[Random.Range(0, matchingCharacters.Count)]; //return random character if specified

        return null; // return null if nothing
    }
    
    
    public int currentTurnIndex = 0; //Who's turn it is 
    public int turnCounter = 0; //Honkai star rail rules. This only increments once everyone got a turn
    public int skillPoints = 3;

    //State machine time babyyyyy
    enum States { Start, Play, End }
    States currentState = States.Start;

    // Update is called once per frame
    void Update() {
        switch (currentState) {
            case States.Start:
                //Adds the gameobjects into a list of participants
                for (int i = 0; i < characterObjects.Count; i++) {
                    if (characterObjects.Count <= 0.0f)
                        break;
                    
                    Character temp = characterObjects[i].GetComponent<Character>();
                    if (temp == null) { continue; }
                    participants.Add(temp);
                }

                //Set the battle manager of the participants to this
                for (int i = 0; i < participants.Count; i++) {
                    if (participants[i] != null) {
                        participants[i].SetBattleManager(this);
                    }
                }

                currentState = States.Play;
                break;

            case States.Play:
                if (!Battle()) { currentState = States.End; }
                break;

            case States.End:
                Debug.Log("Battle is over");
                manager.CloseBattleScreen();
                break;
        }
    }

    public bool Battle() {

        if (GameOver()) {
            return false; //Ends the battle if the conditions have been met
        }

        DebugPrintBattleStatus();
        /*if (battleStats != null) {
            battleStats.setText(participants[currentTurnIndex]);
        }*/
        
        //If the turn has finished
        if (!participants[currentTurnIndex].StartTurn(skillPoints)) {
            //changer.setSkillPoints(skillPoints);
            currentTurnIndex++;
        }
        

        //If the turn index has gone through every participant, start from the beginning
        if (currentTurnIndex > participants.Count - 1) {
            currentTurnIndex = 0;
            turnCounter++;
            //changer.setCurrentTurn(turnCounter);
        }
        

        return true;
    }

    //Check the gameover condition
    bool GameOver() {
        if (participants.Count <= 0) { return true; }

        //Check if there are enemies and teammates on the field, THAT are not dead
        bool playerAlive = false;
        bool enemiesAlive = false;

        //Check if players are alive
        for (int i = 0; i < participants.Count; i++) {
            if (!GetAdrielCharacter().isDead || !GetDianaCharacter().isDead || !GetMichaelCharacter().isDead) {
                playerAlive = true;
                break;
            }
        }

        //Check if enemies are alive
        for (int i = 0; i < participants.Count; i++) {
            var otherCharacter = GetOtherCharacter<Character_DrSottLeaver>();
            if (otherCharacter != null && !otherCharacter.hasLeft) {
                enemiesAlive = true;
                break;
            }
        }

        return !playerAlive && !enemiesAlive;
    }

    void DebugPrintBattleStatus() {
        Debug.Log(participants[currentTurnIndex].gameObject.name + " | Turn Index: " + currentTurnIndex + " | Turn Counter: " + turnCounter + " | Skill Points: " + skillPoints);
    }

    public void Reset() {
        currentTurnIndex = 0;
        turnCounter = 0; 
        skillPoints = 3;
        currentState = States.Start;
        participants.Clear();
    }

    public Character GetCurrentParticipant() { 
        if(currentTurnIndex == 0) return null;
        if (currentTurnIndex > participants.Count) return null;
        return participants[currentTurnIndex];
    }
}