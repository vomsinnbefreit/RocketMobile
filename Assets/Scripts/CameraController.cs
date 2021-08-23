using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
	[SerializeField] Vector3 offset;

	[SerializeField] float smoothingSpeed = 10f;

	private void FixedUpdate()
	{
		Vector3 targetPos = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothingSpeed);

		transform.LookAt(target);
	}
}
