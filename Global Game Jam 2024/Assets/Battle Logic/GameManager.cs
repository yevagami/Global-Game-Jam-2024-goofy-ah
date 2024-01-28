using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    enum GameState { Overworld, Battle}
    GameState current = GameState.Overworld;
    [SerializeField] BattleManager battleManager;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
       
    }
}
