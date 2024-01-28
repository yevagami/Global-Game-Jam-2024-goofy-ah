using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    enum GameState { Overworld, Battle}
    GameState current = GameState.Overworld;
    [SerializeField] BattleManager battleManager;
    public bool StartBattle = false;
    public bool EndBattle = false;

    // Start is called before the first frame update
    void Start(){
        battleManager.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        if (StartBattle)
        {
            // no memory leaks here! lets make sure to not infinitely loop #recursion
            StartBattle = false;
            OpenBattleScreen(null);
        }

        if (EndBattle) {
            EndBattle = false;
            CloseBattleScreen();
        }
    }

    //Opens the battle screen
    public void OpenBattleScreen(GameObject opponent) {
        if(opponent != null) {
            Character temp = opponent.GetComponent<Character>();
            battleManager.GetParticipants().Add(temp);
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BattleScene");
        battleManager.enabled = true;
    }

    //Closes the battle screen
    public void CloseBattleScreen() {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Overworld");
        battleManager.Reset();
        battleManager.enabled = false;
    }
}
