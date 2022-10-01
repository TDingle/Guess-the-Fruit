using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New RuntimeData")]
public class RunTimeData : ScriptableObject
{
    public string CurrentFoodMousedOver;
    public GameplayState CurrentGameplayState;
}
