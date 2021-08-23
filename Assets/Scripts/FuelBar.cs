using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] Image fuelBar;
    [SerializeField] RocketController rocket;
    [SerializeField] RocketStats stats;
	[SerializeField] FuelUpgrade fuelUpgrade;


	float fuel, maxFuel;
	float lerpSpeed;

	private void Start()
	{
		maxFuel = fuelUpgrade.tank;
	}

	private void Update()
	{
		fuel = rocket.currentFuel;

		lerpSpeed = 3f * Time.deltaTime;

		FuelBarFiller();
		ColorChanger();
	}

	private void FuelBarFiller()
	{
		fuelBar.fillAmount = Mathf.Lerp(fuelBar.fillAmount, fuel / maxFuel, lerpSpeed);
	}

	void ColorChanger()
	{
		Color fuelColor = Color.Lerp(Color.red, Color.green, (fuel / maxFuel));

		fuelBar.color = fuelColor;
	}
}
