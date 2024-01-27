using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    List<Character> participants = new List<Character>();

    int currentTurnIndex = 0; //Who's turn it is 
    int turnCounter = 0; //Honkai star rail rules. This only increments once everyone got a turn
    int skillPoints = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle()) {
            Debug.Log("Battle is over");
        }
    }

    public bool Battle() {
        if (GameOver()) {
            return false; //Ends the battle if the conditions have been met
        }

        currentTurnIndex++;


    }


    bool GameOver() {
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

        return playerAlive && enemiesAlive;
    }
}
