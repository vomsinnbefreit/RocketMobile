using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RocketController : MonoBehaviour
{
	public InputMaster controls;

	[Header("UI")]
	[SerializeField] TextMeshProUGUI meterText;

	[Header("Data")]
	public float currentFuel;
	public bool isGrounded = false;
	[SerializeField] float thrusterFroce = 10f;
	[HideInInspector] public bool dead = false;
	int currentScore;

	[Header("References")]
	[SerializeField] RocketStats stats;
	[SerializeField] FuelUpgrade fuelUpgrade;


	[SerializeField] ParticleSystem rocketEngine;
	[SerializeField] ParticleSystem explosionEffect;
	[SerializeField] GameObject meshes;
	public Rigidbody rb;

	Quaternion deltaRotation;
	bool turning = false;
	bool thrustEnabled = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		GameManager.Instance.gameState = GameState.InGame;


		controls = new InputMaster();

		controls.Player.Thrust.performed += ctx => EnableThrust();

		controls.Player.RotateLeft.performed += ctx => TurnLeft();
		controls.Player.RotateRight.performed += ctx => TurnRight();

		controls.Player.RotateLeft.canceled += ctx => StopTurning();
		controls.Player.RotateRight.canceled += ctx => StopTurning();
	}

	private void Start()
	{
		currentFuel = fuelUpgrade.tank;
	}

	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}

	private void Update()
	{
		if (controls.Player.Thrust.WasReleasedThisFrame())
		{
			thrustEnabled = false;
		}

		if (thrustEnabled)
		{
			currentFuel = currentFuel - Time.deltaTime;
		}

		currentScore = (int)transform.position.x;
		meterText.text = currentScore.ToString();
	}

	void FixedUpdate()
	{
		if (currentFuel > 0 && thrustEnabled)
		{
			rb.AddRelativeForce(Vector3.up * thrusterFroce * Time.deltaTime);
			rocketEngine.Play();
		}
		if (turning)
		{
			rb.MoveRotation(rb.rotation * deltaRotation);
		}
	}

	public void TurnLeft()
	{
		Vector3 rot = new Vector3(0, 0, 25);
		deltaRotation = Quaternion.Euler(rot * Time.fixedDeltaTime);
		turning = true;
	}

	public void TurnRight()
	{
		Vector3 rot = new Vector3(0, 0, -25);
		deltaRotation = Quaternion.Euler(rot * Time.fixedDeltaTime);
		turning = true;
	}

	void StopTurning()
	{
		turning = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin"))
		{
			AddCoin(other);
		}
		else
		{
			DestroyRocket();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Obstacle"))
		{
			DestroyRocket();
		}
		else if (collision.collider.CompareTag("Coin"))
		{
			AddCoin(collision.collider);
		}
		else if (collision.collider.CompareTag("GasPortGround"))
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("GasPortGround"))
		{
			isGrounded = false;
		}
	}

	void TouchThrust()
	{
		thrustEnabled = true;
	}

	void EnableThrust()
	{
		thrustEnabled = true;
	}


	private void DestroyRocket()
	{
		if(dead == false)
		{
			explosionEffect.Play();
			meshes.SetActive(false);

			if (currentScore > stats.maxScore)
			{
				stats.maxScore = currentScore;
			}

			dead = true;

			GameManager.Instance.gameState = GameState.RetryMenu;
		}
	}

	void AddCoin(Collider collider)
	{
		stats.coins += 1;
		Destroy(collider.gameObject);

	}
}
