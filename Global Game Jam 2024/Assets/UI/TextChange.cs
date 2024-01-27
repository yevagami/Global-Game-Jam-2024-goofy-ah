using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public TextMeshProUGUI nameOfTheCurrentChar;
   
    // Start is called before the first frame update
    public void setText(Character character) { 

        nameOfTheCurrentChar.text = character.name;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
