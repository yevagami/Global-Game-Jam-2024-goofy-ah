using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;

    public BattleManager bm;
    Character_DrSottLeaver j;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake() { 
        slider = GetComponentInParent<Slider>();
        bm = GetComponentInParent<BattleManager>();
       j = bm.GetOtherCharacter<Character_DrSottLeaver>();


    }
    // Update is called once per frame
    void Update()
    {
        slider.value = j.currentHealth;
    }
}
