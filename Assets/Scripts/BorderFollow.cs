using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderFollow : MonoBehaviour
{
    float moveSpeed = 1f;

    [SerializeField] Transform rocket;

	void Start()
	{
		Transform[] children = GetComponentsInChildren<Transform>();

		foreach(Transform i in children)
		{
			if(i != this.transform)
				i.rotation = Quaternion.Euler(new Vector3 (Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
		}
	}

    void Update()
	{

		transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);

		if (transform.position.x < rocket.position.x - 60)
		{
			transform.position = new Vector3(rocket.position.x - 40, 0, 0);
		}
	}


}
