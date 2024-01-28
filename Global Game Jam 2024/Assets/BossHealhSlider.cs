using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealhSlider : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Character_DrSottLeaver sott;
    // Start is called before the first frame update

    private void FixedUpdate() {
        healthBar.value = sott.currentHealth / sott.baseHealth;
    }
}
