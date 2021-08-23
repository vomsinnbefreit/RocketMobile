using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public int drawDistance;
	[SerializeField] Transform rocket;
	[SerializeField] Transform destructionPoint;
	[SerializeField] Transform biomeChange;

	public List<Biome> biomes = new List<Biome>();

	Biome activeBiome;

	public float pieceLength;

	Queue<GameObject> activePieces = new Queue<GameObject>();

	int currentCamStep = 0;
	int lastCamStep = 0;

	private void Start()
	{
		activeBiome = biomes[0];

		for (int i = 0; i < drawDistance; i++)
		{
			SpawnNewLevelPiece();
		}

		currentCamStep = (int)(destructionPoint.transform.position.x / pieceLength);
		lastCamStep = currentCamStep;
	}

	private void Update()
	{
		currentCamStep = (int)(destructionPoint.transform.position.x / pieceLength);
		if(currentCamStep != lastCamStep)
		{
			lastCamStep = currentCamStep;

			DespawnLevelPiece();
			SpawnNewLevelPiece();
		}

		if(biomeChange.position.x < rocket.position.x)
		{
			Debug.Log("Changein");
			biomeChange.position = new Vector3(rocket.position.x + 300, 0, 0);
			int i = Random.Range(0, biomes.Count);
			Debug.Log(i);
			activeBiome = biomes[i];
		}
	}

	void SpawnNewLevelPiece()
	{
		GameObject newLevelPiece = Instantiate(activeBiome.biome[Random.Range(0, activeBiome.biome.Count)].prefab, new Vector3((currentCamStep + activePieces.Count) * pieceLength, 0f, 0f), Quaternion.identity);
		activePieces.Enqueue(newLevelPiece);
	}

	void DespawnLevelPiece()
	{
		GameObject oldLevelPiece = activePieces.Dequeue();
		Destroy(oldLevelPiece);
	}
}

[System.Serializable]
public class LevelPiece
{
	public GameObject prefab;
}

[System.Serializable]
public class Biome
{
	public List<LevelPiece> biome = new List<LevelPiece>();
}
