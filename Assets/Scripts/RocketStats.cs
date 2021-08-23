using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RocketStat", menuName = "ScriptableObject/RocketStats")]
public class RocketStats : ScriptableObject
{
    public int maxScore;
    public int coins;
}
