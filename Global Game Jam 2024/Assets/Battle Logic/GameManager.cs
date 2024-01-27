using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    enum GameState { Overworld, Battle}
    GameState current = GameState.Overworld;
    [SerializeField] BattleManager battleManager;
    public bool ChageScreen = false;

    // Start is called before the first frame update
    void Start(){
        battleManager.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        if (ChageScreen) {
            OpenBattleScreen(null);
        }
    }

    void OpenBattleScreen(GameObject opponent) {
        if(opponent != null) {
            battleManager.characterObjects.Add(opponent);
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BattleScene");
        battleManager.enabled = true;
    }

    void CloseBattleScreen() { }
}
