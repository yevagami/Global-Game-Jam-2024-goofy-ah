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

    public Image portraitRenderer;

    [SerializeField] Slider healthSlider;

    // Start is called before the first frame update
    public void setText() {
        Character currentChar = bm.GetParticipants()[bm.currentTurnIndex];
        nameOfTheCurrentChar.text = currentChar.name.ToString();
        currentHP.text = currentChar.currentHealth.ToString();
        currentDef.text = currentChar.currentDefense.ToString();
        currentAttack.text = currentChar.currentAttack.ToString();
        currentBossName.text = "Dr. Sott Leaver (PH.D)";

        currentSkillPoints.text = bm.skillPoints.ToString();
        currentTurn.text = bm.turnCounter.ToString();
        portraitRenderer.sprite = currentChar.portrait;
        healthSlider.value = currentChar.currentHealth / currentChar.baseHealth; 
    }

    public void setSkillPoints(int currnetSkillpoints) { 
        currentSkillPoints.text = currnetSkillpoints.ToString();
    }
    public void setCurrentTurn(int currnetTurn)
    {
            currentTurn.text = currnetTurn.ToString();
    }
    // Update is called once per frame

    private void FixedUpdate() {
        setText();
    }
}
