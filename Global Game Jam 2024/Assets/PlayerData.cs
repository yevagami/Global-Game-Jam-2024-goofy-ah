using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Custom ScriptableObjects") ]
public class PlayerData : ScriptableObject{
   public float health;
   public float energy;
}
