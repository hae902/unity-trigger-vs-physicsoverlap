using System.Collections.Generic;
using UnityEngine;

public class PhysicsArea : MonoBehaviour
{
	[SerializeField] private LayerMask layerMask = new LayerMask();
	[SerializeField] private float radius = 0f;

	private const int maxOverlapCollider = 64;
	private Collider[] overlapColliders = new Collider[maxOverlapCollider];
	private List<GameObject> gameObjectsInTrigger = new List<GameObject>(maxOverlapCollider);

	private void Update()
	{
		gameObjectsInTrigger.Clear();

		var overlap = Physics.OverlapSphereNonAlloc(transform.position, radius, overlapColliders, layerMask);
		for (var i = 0; i < overlap; i++)
			gameObjectsInTrigger.Add(overlapColliders[i].gameObject);
		// Debug.LogFormat("Count: {0}", gameObjectsInTrigger.Count);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}