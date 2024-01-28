using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public BattleManager bm;

    public TextMeshProUGUI nameOfTheCurrentChar;
    //stats
    public TextMeshProUGUI currentHP;
    public TextMeshProUGUI currentDef;
    public TextMeshProUGUI currentAttack;


    // turns and skill points
    public TextMeshProUGUI currentSkillPoints;
    public TextMeshProUGUI currentTurn;

    // boss
    public TextMeshProUGUI currentBossName;


    // Start is called before the first frame update
    public void Awake() {
        bm = GetComponentInParent<BattleManager>();
    }
    public void setText(Character character) {
        Character currentChar = bm.GetParticipants()[bm.currentTurnIndex];
        nameOfTheCurrentChar.text = currentChar.name.ToString();
        currentHP.text = currentChar.currentHealth.ToString();
        currentDef.text = currentChar.currentDefense.ToString();
        currentAttack.text = currentChar.currentAttack.ToString();
        currentBossName.text = bm.GetCharacterByTeam<Character>(Character.Team.ENEMY, "Dr. Sott Leaver (PH.D)").name.ToString();

        currentSkillPoints.text = bm.skillPoints.ToString();
        currentTurn.text = bm.currentTurnIndex.ToString();

      
        
    }
    public void setSkillPoints(int currnetSkillpoints) { 
        currentSkillPoints.text = currnetSkillpoints.ToString();
    }
    public void setCurrentTurn(int currnetTurn)
    {
            currentTurn.text = currnetTurn.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
