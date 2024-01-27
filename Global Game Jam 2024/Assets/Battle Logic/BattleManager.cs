using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    //For the sake of testing
    public List<GameObject> characterObjects = new List<GameObject>();
    List<Character> participants = new List<Character>();
    public List<Character> GetParticipants() { return participants; }

    public int currentTurnIndex = 0; //Who's turn it is 
    public int turnCounter = 0; //Honkai star rail rules. This only increments once everyone got a turn
    public int skillPoints = 3;
    
    //State machine time babyyyyy
    enum States { Start, Play, End}
    States currentState = States.Start;

    // Update is called once per frame
    void Update(){
        switch (currentState) {
            case States.Start:
                //Adds the gameobjects into a list of participants
                for(int i = 0; i < characterObjects.Count; i++) {
                    Character temp = characterObjects[i].GetComponent<Character>();
                    if(temp == null) { continue; }
                    participants.Add(temp);
                }

                //Set the battle manager of the participants to this
                for(int i = 0; i < participants.Count; i++) {
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
                break;
        }
    }

    public bool Battle() {

        if (GameOver()) {
            return false; //Ends the battle if the conditions have been met
        }

        DebugPrintBattleStatus();

        //If the turn has finished
        if (!participants[currentTurnIndex].StartTurn(skillPoints)) {
            currentTurnIndex++;
        }

        //If the turn index has gone through every participant, start from the beginning
        if (currentTurnIndex > participants.Count - 1) {
            currentTurnIndex = 0;
            turnCounter++;
        }

        return true;
    }

    //Check the gameover condition
    bool GameOver() {
        if(participants.Count <= 0) { return false; }

        //Check if there are enemies and teammates on the field, THAT are not dead
        bool playerAlive = false;
        bool enemiesAlive = false;

        //Check if players are alive
        for(int i = 0; i < participants.Count; i++) {
            if (participants[i].currentTeam == Character.Team.FRIEND && participants[i].isDead == false) {
                playerAlive = true;
                break;
            }
        }

        //Check if enemies are alive
        for(int i = 0; i < participants.Count; i++) {
            if (participants[i].currentTeam == Character.Team.ENEMY && participants[i].isDead == false) {
                enemiesAlive = true;
                break;
            }
        }

        return !playerAlive && !enemiesAlive;
    }

    void DebugPrintBattleStatus() {
        Debug.Log(participants[currentTurnIndex].gameObject.name + " | Turn Index: " +  currentTurnIndex + " | Turn Counter: " + turnCounter + " | Skill Points: " + skillPoints);
    }
}
