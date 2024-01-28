using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHPbar : MonoBehaviour
{
    public BattleManager bm;
    public Slider slider;

    public void Awake()
    {
        bm = GetComponentInParent<BattleManager>();
    }

    public void SetMaxHealth() {
        slider.maxValue = 1;
        slider.value = bm.GetCurrentParticipant().currentHealth / bm.GetCurrentParticipant().baseHealth;
    }
    
    public void SetHealth() {
        slider.value = bm.GetCurrentParticipant().currentHealth / bm.GetCurrentParticipant().baseHealth;
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
