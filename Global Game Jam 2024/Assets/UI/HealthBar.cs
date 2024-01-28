using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {
    public Slider slider;
  
    public BattleManager bm;

    void Update()
    {
        Character character = bm.GetCurrentParticipant();
        slider.maxValue = character.baseHealth;
        slider.value = character.currentHealth;
       
    }
}
