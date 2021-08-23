using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public enum GameState
{
	InGame,
	RetryMenu,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] RocketStats stats;
	[SerializeField] FuelUpgrade fuelUpgrade;

	[SerializeField] RocketController rocket;

	[SerializeField] TextMeshProUGUI highScore;
	[SerializeField] TextMeshProUGUI coins;
	[SerializeField] RectTransform retryScreen;

	public static GameManager Instance;

	public GameState gameState;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		highScore.text = stats.maxScore.ToString();
		coins.text = stats.coins.ToString();

		if (rocket.isGrounded)
		{
			rocket.currentFuel = fuelUpgrade.tank;

		}

		if(gameState == GameState.InGame)
		{
			retryScreen.GetComponent<Animator>().SetBool("retryScreen", false);
			rocket.rb.isKinematic = false;
			rocket.enabled = true;
		}
		else if(gameState == GameState.RetryMenu)
		{
			retryScreen.GetComponent<Animator>().SetBool("retryScreen", true);
			rocket.rb.isKinematic = true;
			rocket.enabled = false;
		}
	}

	public void SetInGameMenu()
	{
		if (gameState == GameState.InGame)
		{
			gameState = GameState.RetryMenu;
		}
		else if (gameState == GameState.RetryMenu && !rocket.dead)
		{
			gameState = GameState.InGame;
		}
	}
}
