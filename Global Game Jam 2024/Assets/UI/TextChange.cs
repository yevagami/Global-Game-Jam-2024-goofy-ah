using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
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
    public void setText(Character character) { 

        nameOfTheCurrentChar.text = character.name;
        currentHP.text = character.currentHealth.ToString();
        currentDef.text = character.currentDefense.ToString();
        currentBossName.text = character.name;
        
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
