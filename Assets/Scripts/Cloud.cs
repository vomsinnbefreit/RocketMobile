using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	Transform destructionPoint;

	private void Start()
	{
		destructionPoint = GameObject.FindGameObjectWithTag("DestructionPoint").transform;
	}

	private void Update()
	{
		float speed = Random.Range(0.2f, 0.6f);

		transform.Translate(Vector3.left * Time.deltaTime * speed);

		if (transform.position.x < destructionPoint.position.x)
		{
			Destroy(gameObject);
		}
	}
}
