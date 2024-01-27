using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
    public Slider slider;
    public Character character;

    void Update()
    {
        slider.value = character.currentHealth;
    }
}
