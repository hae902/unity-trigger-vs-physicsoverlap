using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsArea : MonoBehaviour
{
	[SerializeField] private LayerMask layerMask = new LayerMask();
	[SerializeField] private float radius = 0f;

	private List<GameObject> gameObjectsInTrigger = new List<GameObject>();

	private void Update()
	{
		gameObjectsInTrigger.Clear();

		foreach (var collider in Physics.OverlapSphere(transform.position, radius, layerMask))
		{
			gameObjectsInTrigger.Add(collider.gameObject);
		}
		// Debug.LogFormat("Count: {0}", gameObjectsInTrigger.Count);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}