using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    enum GameState { Overworld, Battle}
    GameState current = GameState.Overworld;
    [SerializeField] BattleManager battleManager;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start(){
        battleManager = new BattleManager();
    }

    // Update is called once per frame
    void Update(){

    }

    void OpenBattleScreen(GameObject opponent) {

    }
}
