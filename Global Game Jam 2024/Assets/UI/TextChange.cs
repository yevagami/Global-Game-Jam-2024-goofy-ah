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

<<<<<<< Updated upstream
    [SerializeField] Slider healthSlider;

=======
    public TextMeshProUGUI passiveDescription;
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI ultimateDescriprion;
>>>>>>> Stashed changes
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

    public void allDesctiptions() {
        Character currentChar = bm.GetParticipants()[bm.currentTurnIndex];
        if (currentChar.name == "Adriel") {
            passiveDescription.text = "Makes enemies despare level inrease by 1 (nutural-> sad -> depressed)";
            skillDescription.text = "Taunts enemies, gains 30% of damage reduction";
            ultimateDescriprion.text = "Makes the enemies instantly depressed";
        }
        if (currentChar.name == "Diana")
        {
            passiveDescription.text = "Heals 10 HP to the teammate with lowest HP on the field every turn";
            skillDescription.text = "Deal damage equal 30% of the attack, and heal self for the damage delt"; //stats
            ultimateDescriprion.text = "Buffs the whole team , deals 50% od current HP ";
        }
        if (currentChar.name == "Michael") 
        {
            passiveDescription.text = "After using a skill there is a 50% chance to do a follow-up attack";
            skillDescription.text = "Deals 25 damage";
            ultimateDescriprion.text = "Increases follow up damage by 25 attack for two turn";
        }
    }

    private void FixedUpdate() {
        setText();
        allDesctiptions();
    }
}
