using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteroit : MonoBehaviour
{
	[SerializeField] float direction = 1;

    float moveSpeed;

	[SerializeField] bool move = true;

	Transform destructionPoint;

	private void Start()
	{
		moveSpeed = Random.Range(-0.1f * direction, -0.6f * direction);

		destructionPoint = GameObject.FindGameObjectWithTag("DestructionPoint").transform;
	}

	private void Update()
	{
		if(move)
			transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);

		if(transform.position.x < destructionPoint.position.x)
		{
			Destroy(gameObject);
		}
	}
}
