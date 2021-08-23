using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
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

			GameObject obj = Instantiate(platformToGenerate, new Vector3(transform.position.x, height, transform.position.z), Quaternion.Euler(Random.Range(0, 360), transform.rotation.y, transform.rotation.z));

			float scale = Random.Range(1.0f, 2.0f);
			obj.transform.localScale = new Vector3(scale, scale, scale);
		}
	}
}
