using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] Vector3 point1, point2;

    [SerializeField] float speed;

    Vector3 currentTarget;

	private void Start()
	{
		point1 += transform.position;
		point2 += transform.position;

		currentTarget = point1;
	}

	private void Update()
	{
		if(transform.position == point1)
		{
			currentTarget = point2;
		}
		if(transform.position == point2)
		{
			currentTarget = point1;
		}

		transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
	}
}
