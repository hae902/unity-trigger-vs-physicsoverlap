using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerArea : MonoBehaviour
{
	private List<GameObject> gameObjectsInTrigger = new List<GameObject>();

	private void Start()
	{
		GetComponent<Collider>().isTrigger = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		gameObjectsInTrigger.Add(other.gameObject);
	}

	private void OnTriggerExit(Collider other)
	{
		gameObjectsInTrigger.Remove(other.gameObject);
	}

	private void Update()
	{
		gameObjectsInTrigger.RemoveAll(item => (item == null) || (!item.activeSelf));
		// Debug.LogFormat("Count: {0}", gameObjectsInTrigger.Count);
	}
}