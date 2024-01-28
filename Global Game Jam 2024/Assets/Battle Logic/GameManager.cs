using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    enum GameState { Overworld, Battle}
    GameState current = GameState.Overworld;
    [SerializeField] BattleManager battleManager;
    
    
}
