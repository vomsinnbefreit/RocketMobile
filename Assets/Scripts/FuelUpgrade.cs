using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuelUpgrade", menuName = "ScriptableObject/FuelUpgrade")]
public class FuelUpgrade : ScriptableObject
{
    [Header("CurrentStats")]
    public int level;
    public int cost;
    public int tank;

    [Header("MaxStats")]
    public int maxLevel;

    [Header("Upgrade")]
    public int costMultiplier;
    public int addTank;
}
