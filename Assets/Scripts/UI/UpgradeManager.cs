using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
	[SerializeField] RocketStats stats;

	//Upgrades
	[SerializeField] FuelUpgrade fuelUpgrade;

	//UI
	[SerializeField] TextMeshProUGUI tankLevel;

	private void Update()
	{
		tankLevel.text = "Level " + fuelUpgrade.level.ToString();
	}

	public void UpgradeTank()
	{
		if(fuelUpgrade.level < fuelUpgrade.maxLevel && stats.coins >= fuelUpgrade.cost)
		{
			fuelUpgrade.tank += fuelUpgrade.addTank;
			fuelUpgrade.level++;
			stats.coins -= fuelUpgrade.cost;
			fuelUpgrade.cost *= fuelUpgrade.costMultiplier;
		}
	}

	public void Quit()
	{
		Application.Quit();
	}
}
