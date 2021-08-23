using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	[SerializeField] Transform generationPoint;

	[SerializeField] float distanceBetweenMin;
	[SerializeField] float distanceBetweenMax;
	[SerializeField] float heightMin;
	[SerializeField] float heightMax;

	[SerializeField] List<GameObject> obstacles = new List<GameObject>();

	GameObject platformToGenerate;
	float distanceBretween;
	float height;
	int platformSelector;

	private void Update()
	{
		if (transform.position.x < generationPoint.position.x)
		{
			distanceBretween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			height = Random.Range(heightMin, heightMax);

			platformSelector = Random.Range(0, obstacles.Count);
			platformToGenerate = obstacles[platformSelector];

			transform.position = new Vector3(transform.position.x + distanceBretween, transform.position.y, transform.position.z);

			Instantiate(platformToGenerate, new Vector3(transform.position.x, height, transform.position.z), Quaternion.Euler(transform.rotation.x, Random.Range(0, 4) * 90, transform.rotation.z));	
		}
	}
}
